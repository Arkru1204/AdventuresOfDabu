using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerController controller;

    private void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            controller.Landing();
        }
    }
}
