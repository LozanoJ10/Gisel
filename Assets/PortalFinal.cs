using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalFinal : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio_Portal;
    public string NombreDeEscena;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            audio_Portal.Play();
            SceneManager.LoadScene(NombreDeEscena);
            
        }
    }
}
