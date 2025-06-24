using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    private void Awake()
    {
        controls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void FixedUpdate()
    {
        // Obliczamy now¹ pozycjê i przekazujemy j¹ do fizyki
        Vector2 newPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
