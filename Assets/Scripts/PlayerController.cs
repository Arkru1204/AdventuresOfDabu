using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private InputAction moveAction;

    private Vector2 moveInput;

    private bool isGrounded = true;

    [Header("Move")]
    [SerializeField, Range(0f, 10f)]
    private float moveSpeed = 5f;
    [SerializeField, Range(0f, 100f)]
    private float jumpPower = 10f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");

        anim.SetBool("isFall", false);
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Moving();
        Falling();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Landing();
        }
    }

    // 플레이어 입력 처리
    private void GetInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    // 플레이어 이동
    private void Moving()
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

    // 플레이어 낙하
    private void Falling()
    {
        if (rigid.linearVelocity.y < 0)
        {
            isGrounded = false;
            anim.SetBool("isFall", true);
        }
    }

    // 플레이어 착지
    private void Landing()
    {
        anim.SetBool("isFall", false);
        anim.SetTrigger("onLand");
    }

    // 플레이어 점프 (Input System의 Jump 액션에서 호출)
    private void OnJump()
    {
        if (rigid.linearVelocity.y != 0) // 이미 점프 중이면
            return;
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Land")) // 현재 실행중인 애니메이션이 착지라면 점프하지 않음
            return;

        isGrounded = false;
        anim.SetTrigger("onJump");
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    // 플레이어 공격 (Input System의 Attack 액션에서 호출)
    private void OnAttack()
    {
        Debug.Log("Attack!");
        anim.SetTrigger("onAttack");
    }
}
