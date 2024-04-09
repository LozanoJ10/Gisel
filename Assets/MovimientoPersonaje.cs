using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Fuerza de salkt
    public Rigidbody2D rb;

    private bool isGrounded; // Esto verifica si esta en el piso para saltar

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        movement = movement.normalized;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        //Comprobar que esta en el suelo para saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
