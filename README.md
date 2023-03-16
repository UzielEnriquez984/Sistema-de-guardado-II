# Sistema de guardado/versión corregida
Éste es un sistema del segundo parcial de la asignatura de Programación para videojuegos II.
# Descrpción general
El sistema está utilizado en un simulador de Ping pong digital, el cual funciona como el registro de los nombres de los jugadores y el marcador de la partida anterior, en la pantalla de "Last Match".
Corresponde a la versión "2022.3.27f1" de Unity.
Está constado por cinco pantallas: el menú, la interfaz de personalización de nombres de los jugadores, el juego de Ping pong, la pantalla de victoria del ganador y el registro del marcador de la partida anterior.
La puntuación de victoria es de diez puntos.
# Controles
Para el movimiento vertical de la raqueta del jugador, las teclas correspondientes son: "W y S"; y para el movimiento vertical de la raqueta del jugador dos, las teclas correspondientes son las flechas de abajo y arriba.
# Codificación 

Kick

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
            
La función de este código es posibilitar el movimiento de la bola y susceptibilizar el funcionamiento del juego.

Menuscreen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    //CARGAR ESCENA DE ULTIMA PARTIDA
    public void LastMatchScreen()
    {
        SceneManager.LoadScene(1);
    }

    //CARGAR ESCENA PAR COMENZAR A JUGAR
    public void PickNameScreen()
    {
        SceneManager.LoadScene(2);
    }

    //CARGAR ESCENA PAR SALIR DE LA APLICACION
    public void Exit()
    {
        Application.Quit();
    }

}

La función de este código es mostrar lo que en sí es el menú, en el cual, el juagor podría optar por iniciar una partida o visualizar el marcador de la anterior partida.

Move

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
       
  La función de este código es susceptibilizar el movimiento de las raquetas, como complemento del código, Kick.
  
  SetNamesScreen
  
  using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetNamesScreen : MonoBehaviour
{
    //VARIABLES DE TEXTO QUE GUARDARAN EL NOMBRE QUE LOS JUGADORES HAN ESCRITO
    public TMP_InputField BOX1;
    public TMP_InputField BOX2;

    //SE GUARDA EL TEXTO DEL INPUT FIELD
    public void SaveNameP1()
    {
        PlayerPrefs.SetString("P1Name", BOX1.text);
    }

    //SE GUARDA EL TEXTO DEL INPUT FIELD
    public void SaveNameP2()
    {
        PlayerPrefs.SetString("P2Name", BOX2.text);
    }

    //METODO PARA REGRESAR A LA ESCENA ANTERIOR
    public void BACK()
    {
        SceneManager.LoadScene(0);
    }

    //METODO PARA COMENZAR A JUGAR
    public void PLAY ()
    {
        SceneManager.LoadScene(3);
    }
}

La función de este código es permitirle al jugador personalizar el nombre consignado en las pantallas: del juego, de victoria del ganador y el registro del marcador de la partida anterior.

WinnerScreen

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinnerScreen : MonoBehaviour
{
   //VARIABLES DE TEXTO QUE GUARDARAN LA PUNTUACION
    public TMP_Text ScoreP1;
    public TMP_Text ScoreP2;


    //VARIABLES DE TEXTO PARA GUARDAR LOS NOMBRES DE LOS JUGADORES
    public TMP_Text NameP1;
    public TMP_Text NameP2;

    void Start()
    {
        //SE CARGAN LOS AJUSTES
        LoadSettings();
    }

    //METODO PARA REGRESAR A LA ESCENA ANTERIOR
   public void BACK()
    {
        SceneManager.LoadScene(0);
    }

    public void QUIT()
    {
        Application.Quit();
    }

    //METODO PARA INVOCAR LA INFORMACION GUARDADA EN PLAYERPREFS
    public void LoadSettings()
    {
        ScoreP1.text = PlayerPrefs.GetInt("PointsP1").ToString();
        ScoreP2.text = PlayerPrefs.GetInt("PointsP2").ToString();
        NameP1.text = PlayerPrefs.GetString("P1Name").ToString();
        NameP2.text = PlayerPrefs.GetString("P2Name").ToString();
    }

La función de este código es mostar el nombre del jugador ganador, una vez que habría logrado anotar diez puntos, una vez finalizada la partida.
