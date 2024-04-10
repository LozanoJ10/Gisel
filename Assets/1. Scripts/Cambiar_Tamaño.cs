using UnityEngine;

public class Cambiar_Tamaño : MonoBehaviour
{
    public bool agrandar;
    public bool achicar;
    public bool original;
    public AudioSource audio_Item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Vector3 escala = collision.transform.localScale;
            if (agrandar)
            {                
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, 
                    collision.gameObject.transform.position.y+1, collision.gameObject.transform.position.z);
                escala *= 2f;
                collision.transform.localScale = escala;
                Destroy(gameObject);
                audio_Item.Play();
            }

            if (achicar)
            {
                escala *= 0.2f;
                collision.transform.localScale = escala;
                Destroy(gameObject);
                audio_Item.Play();
            }

            if (original)
            {
                collision.transform.localScale = Vector3.one;
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x,
                    collision.gameObject.transform.position.y + 0.5f, collision.gameObject.transform.position.z);
                Destroy(gameObject);
                audio_Item.Play();
            }
        }
    }
}
