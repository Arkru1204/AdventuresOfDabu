using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;

    private InputAction moveAction;

    private Vector2 moveInput;

    [Header("Move")]
    [SerializeField, Range(0f, 10f)]
    private float moveSpeed = 5f;
    [SerializeField, Range(0f, 100f)]
    private float jumpPower = 10f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (moveInput.x != 0)
        {
            rigid.linearVelocity = new Vector2(moveInput.x * moveSpeed, rigid.linearVelocity.y);
        }
        else
        {
            rigid.linearVelocity = new Vector2(0f, rigid.linearVelocity.y);
        }
    }

    private void OnJump()
    {
        if (rigid.linearVelocity.y != 0)
            return;

        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
