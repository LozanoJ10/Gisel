using Unity.VisualScripting;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeedMultiplier = 2f; // Factor de multiplic para la velocidad de correr
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public Animator animacionPersonaje;
    public float horizontal;
    private bool enSuelo;
    public AudioSource audio_Salto;
    public bool enPlataforma;
    public bool soyGrande;
    public bool soyPequeño;
    public bool soyNormal;
    public bool rayCastPlat;
    public LayerMask sueloLayer; // Capa del suelo

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacionPersonaje = GetComponent<Animator>();
    }

    private void Update()
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

        // Lanzar un Raycast hacia abajo desde el centro del personaje
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, sueloLayer);
        if (hit.collider != null && hit.collider.CompareTag("Plataforma"))
        {
            this.transform.SetParent(hit.transform);
            enPlataforma = true;
        }
        else {
            this.transform.SetParent(null);
            enPlataforma = false;
        }

        // Dibujar la línea del Raycast en el Editor de Unity
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (Input.GetKeyDown(KeyCode.Space) && enPlataforma)
        {
            rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (enSuelo || enPlataforma))
        {
            animacionPersonaje.SetBool("Saltando", true);
            audio_Salto.Play(); // arrastrando el audiosource dentro de Audiomanager. El que lleva el clip Salto
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            enPlataforma = true;
            collision.transform.SetParent(collision.transform);
        }
        if (collision.gameObject.CompareTag("Suelo") && soyGrande && collision.gameObject.GetComponent<Rigidbody2D>())
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }

        if (collision.gameObject.CompareTag("Plataforma"))
        {
            enPlataforma = false;
        }
    }

    void Jump()
    {
        if (enSuelo || enPlataforma)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
