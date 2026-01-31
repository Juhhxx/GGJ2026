using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private Rigidbody2D _rb;
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float moveAmountHorizontal = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        float moveAmountVertical = Input.GetAxisRaw("Vertical") * _moveSpeed;
        _rb.linearVelocity = new Vector2(moveAmountHorizontal, moveAmountVertical);
    }
}
