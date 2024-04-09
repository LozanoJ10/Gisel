using UnityEngine;

public class Cambiar_Tamaño : MonoBehaviour
{
    public bool agrandar;
    public bool achicar;
    public bool original;

    private void OnTriggerEnter2D(Collider2D collision)
    {       

        if (collision.gameObject.CompareTag("Jugador") && agrandar)
        {
            collision.transform.localScale *= 1.5f;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Jugador") && achicar)
        {
            collision.transform.localScale *= 0.5f;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Jugador") && original)
        {
            collision.transform.localScale = new Vector3(1f,1f,1f);
            Destroy(this.gameObject);
        }
    }
}
