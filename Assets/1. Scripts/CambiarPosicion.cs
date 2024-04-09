using UnityEngine;

public class CambiarPosicion : MonoBehaviour
{
    public Transform posicionInicial;
    public Transform posicionFinal;
    private Transform posicionDestino;

    public bool esPosInicial;
    public bool esPosFinal;
    public AudioSource audio_Portal;

    public float desplazamientoEnX; // CUANTO A LA IZQUIERDA DEL OBJETO VA A SPAWNEAR. 

    //Corregir esto con una ubicacion en particular. Pero puede srevir como esta.

    void Start()
    {
        if (esPosInicial) // Esta logica hace que la posicion Final o inicial sean la "destino" PERO puedes poner un nuevo objeto.
        {
            posicionDestino = posicionFinal;
        }

        if (esPosFinal)
        {
            posicionDestino = posicionInicial;
        }

        //posicion Destino. Se puede acomodar para cada destino, Pero debes acomodarlo como un objeto aparte.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            audio_Portal.Play();
            Vector3 nuevaPosicion = posicionDestino.position;
            nuevaPosicion.x += desplazamientoEnX; // AQUI LE DECIMOS cuantas unidades a la derecha esta de la posicion Final.
            collision.transform.position = nuevaPosicion;
            
        }
    }
}
