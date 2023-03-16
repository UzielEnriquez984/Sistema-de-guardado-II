using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    //VARIABLE PARA INTERACTUAR CON LAS FISICAS DEL OBJETO
    private Rigidbody2D BallBody;

    //VARIABLES PARA EL DESPLAZAMIENTO DE LA PELOTA
    [SerializeField] private float GoSpeed = 4f;
    [SerializeField] private float velocityImpulse = 1.1f;

    private void Start()
    {
        //SELECCIONO EL RIGIDBODY DE LA PELOTA
        BallBody = GetComponent<Rigidbody2D>();
        
        //LA PELOTA SE MUEVE
        GoBall();
    }

    //METODO PARA MOVER LA PELOTA DE UNA MANERA ALEATORIA AL INICIO DEL JUEGO
    private void GoBall()
    {
        //LE DAMOS UN RANGO DE TRAYTECTORIA EN EL EJE DE LAS X
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        //LE DAMOS UN RANGO DE TRAYECTORIA EN EL EJE DE LAS Y
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;

        //COMPARTIMOS ESTOS VALORES CON LA POSICION DE BALL
        BallBody.velocity = new Vector2(xVelocity, yVelocity) * (GoSpeed);
    }

    //COMPARAMOS LAS ETIQUETAS PARA PODER IMPULSAR LA PELOTA
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Raqueta"))
        {
            BallBody.velocity *= velocityImpulse;
        }
    }

    //COMPARAMOS LAS ETIQUETAS PARA ACTUALIZAR EL MARCADOR Y REINICIAR EL TABLERO
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            GameManager.instance.GoalP2();
            GameManager.instance.Restart();
            GoBall();

        }

        else
        {
            GameManager.instance.GoalP1();
            GameManager.instance.Restart();
            GoBall();

        }

    }
}
