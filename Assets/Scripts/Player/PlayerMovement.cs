using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private float _sneakMultiplier = 0.25f;
    [SerializeField] private Rigidbody2D _rb;
    private float _moveAmountHorizontal;
    private float _moveAmountVertical;
    private Vector2 _direction;
    public Vector2 Direction => _direction;
    private void Update()
    {
        Move();
        Sneak();
        ApplyMovement();
    }
    private void Move()
    {
        _moveAmountHorizontal = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        _moveAmountVertical = Input.GetAxisRaw("Vertical") * _moveSpeed;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical")) >= 1) _direction = new Vector2(_moveAmountHorizontal, _moveAmountVertical).normalized;
    }
    private void Sneak()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _moveAmountHorizontal *= _sneakMultiplier;
            _moveAmountVertical *= _sneakMultiplier;
        }
    }
    private void ApplyMovement()
    {
        _rb.linearVelocity = new Vector2(_moveAmountHorizontal, _moveAmountVertical);
    }
}
