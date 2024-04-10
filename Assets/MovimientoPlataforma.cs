using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public Transform punto1;
    public Transform punto2;
    public float velocidad;
    private float tiempoInicio;
    private float distanciaEntrePuntos;
    private Transform jugador;


    void Start()
    {
        tiempoInicio = Time.time;
        distanciaEntrePuntos = Vector3.Distance(punto1.position, punto2.position);
    }

    void Update()
    {
        float tiempoTranscurrido = (Time.time - tiempoInicio) * velocidad;
        float t = Mathf.PingPong(tiempoTranscurrido / distanciaEntrePuntos, 1f);
        transform.position = Vector3.Lerp(punto1.position, punto2.position, t);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            jugador = collision.transform;
            jugador.SetParent(transform, true);
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador") && jugador != null)
        {
            jugador.SetParent(null);
            jugador = null;
        }
    }
}
