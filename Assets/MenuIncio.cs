using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIncio : MonoBehaviour
{
    // Start is called before the first frame update
    public string NombreDeEscena;
    public Animator anim;
    public AudioSource audi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
                {
                    animacion();
                    
                }
    }
    public void animacion()
    {
        audi.Play();
        anim.SetBool("Inicio",true);
    }
    public void Iniciar()
    {
        SceneManager.LoadScene(NombreDeEscena);
    }
}
