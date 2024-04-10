using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class CaidaReiniciar : MonoBehaviour
{
    public GameObject ubiciacionInicial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Jugador"))
        {
            collision.gameObject.transform.position = ubiciacionInicial.transform.position;
        }
    }

}
