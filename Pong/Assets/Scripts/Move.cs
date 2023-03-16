using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    //SERIALIZEDFIELD NOS PERMITE HACER VISIBLE UNA VARIABLE PRIVADA DESDE EL INSPECTOR

    //SPEED SE ENCARGA DE LA VELOCIDAD DE AMBOS JUGADORES

    [SerializeField] private float speed = 7f;

    //ESTE BOOLEANO ASIGNA CUAL DE LOS RECTANGULOS ES EL PLAYER 1

    [SerializeField] private bool P1;


    //CREAMOS UNA VARIABLE CON LA POSICION DE LAS PAREDES DE LA CANCHA (REVISAR DESDE EL CANVAS)

    private float Borders = 3.77f;


    void Update()
    {
        //DECLARAMOS UNA VARIABLE QUE MANIPULARA EL DESPLAZAMIENTO DE LOS JUGADORES A TRAVES DE LAS TECLAS QUE PRESIONEN
        float movement;

        if (P1 == true)
        {
            //GETAXISRAW NECESITA EL NOMBRE QUE APARECE EN EL INPUT MANAGER PARA DETERMINAR EL TIPO DE MOVIMIENTO
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical 2");
        }

        //VARIABLE PARA MODIFICAR LA POSICION DEL OBJETO
        Vector2 posicionJugador = transform.position;

        // A TRAVES DE UN MATCH CLAMP CREAMOS UN RANGO DE MOVIMIENTO PARA EL JUGADOR
        posicionJugador.y = Mathf.Clamp(posicionJugador.y + movement * speed * Time.deltaTime, -Borders, Borders);

        // ACTUALIZAMOS LA POSICION DE LOS JUGADORES
        transform.position = posicionJugador;
    }
}
