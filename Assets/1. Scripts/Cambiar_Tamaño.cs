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
                collision.transform.localScale = new Vector3(3f, 3f, 3f);
                //collision.transform.localScale = escala;
                Destroy(gameObject);
                audio_Item.Play();
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyGrande = true;
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyNormal = false;
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyPequeño = false;
            }

            if (achicar)
            {
                collision.transform.localScale = new Vector3(0.2f, 0.2f,0.2f);
                //collision.transform.localScale = escala;
                Destroy(gameObject);
                audio_Item.Play();
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyGrande = false;
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyNormal = false;
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyPequeño = true;
            }

            if (original)
            {
                collision.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x,
                    collision.gameObject.transform.position.y + 0.5f, collision.gameObject.transform.position.z);
                Destroy(gameObject);
                audio_Item.Play();
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyGrande = false;
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyNormal = true;
                collision.gameObject.GetComponent<MovimientoPersonaje>().soyPequeño = false;

            }
        }
    }
}
