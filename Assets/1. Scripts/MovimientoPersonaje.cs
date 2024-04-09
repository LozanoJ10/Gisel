using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeedMultiplier = 2f; // Factor de multiplicación para la velocidad de carrera
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public Animator animacionPersonaje;
    public float horizontal;
    private bool enSuelo;

    private void Start()
    {
        animacionPersonaje = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0f);
        movement = movement.normalized;

        float currentMoveSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && horizontal != 0)
        {
            currentMoveSpeed *= runSpeedMultiplier;
        }

        rb.velocity = new Vector2(movement.x * currentMoveSpeed, rb.velocity.y);

        if (horizontal < 0) //Cambio direccion de sprite para la animacion. 
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }


        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            animacionPersonaje.SetBool("Saltando", true);
            Jump();
        }
        else
        {
            animacionPersonaje.SetBool("Saltando", false);
        }

        animacionPersonaje.SetBool("Caminando", horizontal != 0);

        animacionPersonaje.SetBool("Correr", Input.GetKey(KeyCode.LeftShift) && horizontal != 0);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }

    void Jump()
    {
        if (enSuelo)
        {            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
