using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Prêdkoœæ ruchu gracza w jednostkach na sekundê")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        // Odczyt wejscia klawiszowego
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Przesuniêcie cia³a fizyki
        rb.MovePosition(rb.position +  movement * moveSpeed * Time.fixedDeltaTime);
    }



}
