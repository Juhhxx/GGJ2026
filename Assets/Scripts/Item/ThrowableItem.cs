using System.Collections;
using System.IO;
using UnityEngine;

public class ThrowableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private Vector2 _impulseStrength = new Vector2 (5, 5);
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private float _stunRadius = 2.5f;
    [SerializeField] private float _stunTime = 2f;
    public void InitialImpulse(Vector2 throwDirection)
    {
        StartCoroutine(InitialImpulseCR(throwDirection));
    }
    private IEnumerator InitialImpulseCR(Vector2 throwDirection)
    {
        _rb2D.AddForce(throwDirection * _impulseStrength, ForceMode2D.Impulse);
        Debug.Log("Impulse Executed");
        Debug.Log(throwDirection);
        yield return new WaitUntil(() => _rb2D.linearVelocity.magnitude <= 0.20f);
        Debug.Log("Reached Velocity 0");
        CheckStunRadius();
        yield return new WaitForSecondsRealtime(_stunTime);
        Destroy(gameObject);
    }
    private void CheckStunRadius()
    {
        Collider2D[] targetsAcquired = Physics2D.OverlapCircleAll(transform.position, _stunRadius);
        Debug.Log(targetsAcquired.Length);
        foreach (Collider2D c in targetsAcquired)
        {
            EnemyBrain enemyBrain = c.GetComponent<EnemyBrain>();
            if (enemyBrain != null)
            {
                if(enemyBrain.EnemyType == _enemyType) enemyBrain.Stun(_stunTime);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;

        Gizmos.DrawWireSphere(transform.position, _stunRadius);
    }
}
