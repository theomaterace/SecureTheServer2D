#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private bool showDebugCollider = true;
    private PlayerInputActions controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    // Dodajemy zmienn¹ koloru
    private Color gizmoColor = Color.yellow;
    private void Awake()
    {
        controls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }
    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private string lastCollisionObjectName = null;

    private void FixedUpdate()
    {
        // Obliczamy now¹ pozycjê i przekazujemy j¹ do fizyki
        Vector2 newPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    private bool isColliding = false;
    // Reakcje na kolizjê
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        lastCollisionObjectName = collision.gameObject.name;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        isColliding = false;
        lastCollisionObjectName = null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!showDebugCollider) return; // Wy³¹czone? Nic nie rysuj

        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        if (circle != null)
        {
            Gizmos.color = isColliding ? Color.red : Color.yellow;
            Gizmos.DrawWireSphere(transform.position + (Vector3)circle.offset, circle.radius);

            if (isColliding && !string.IsNullOrEmpty(lastCollisionObjectName))
            {
                Vector3 labelPosition = transform.position + Vector3.up * 1.0f;
                GUIStyle style = new GUIStyle
                {
                    normal = { textColor = Color.white },
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter
                };

                Handles.Label(labelPosition, $"Kolizja z: {lastCollisionObjectName}", style);
            }
        }
    }
#endif


}
