using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private float _sneakMultiplier = 0.25f;
    [SerializeField] private Rigidbody2D _rb;
    float moveAmountHorizontal;
    float moveAmountVertical;
    private void Update()
    {
        Move();
        Sneak();
        ApplyMovement();
    }
    private void Move()
    {
        moveAmountHorizontal = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        moveAmountVertical = Input.GetAxisRaw("Vertical") * _moveSpeed;
    }
    private void Sneak()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveAmountHorizontal *= _sneakMultiplier;
            moveAmountVertical *= _sneakMultiplier;
        }
    }
    private void ApplyMovement()
    {
        _rb.linearVelocity = new Vector2(moveAmountHorizontal, moveAmountVertical);
    }
}
