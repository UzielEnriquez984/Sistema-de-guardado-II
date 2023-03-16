using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //CONVERTIMOS ESTA CLASE EN STATIC PARA PODER ACCEDER A ELLA DESDE OTROS CODIGOS
    public static GameManager instance;

    //VARIABLES PARA GUARDAR LAS POSICIONES DE LOS ELEMENTOS DEL JUEGO
    [SerializeField] private Transform Player1;
    [SerializeField] private Transform Player2;
    [SerializeField] private Transform Ball;

    [HideInInspector] public int Score1;
    [HideInInspector] public int Score2;

    //VARIABLES DE TEXTO QUE CONTIENEN LA PUNTUACION DE LOS JUGADORES
    public TMP_Text ScoreP1;
    public TMP_Text ScoreP2;

    //VARIABLES DE TEXTO QUE CONTIENEN LOS NOMBRES DE LOS JUGADORES
    public TMP_Text NameP1;
    public TMP_Text NameP2;



    public void Start()
    {
        //SETEAMOS EL SCORE EN 0 PARA COMENZAR A JUGAR UNA NUEVA PARTIDA
        Score1 = 0; Score2 = 0;

        //INICIALIZAMOS EL SINGLETON
        if (instance != null)
        {
            return;
        }

        else
        {
            instance = this;
        }

        //INVOCAMOS LOS NOMBRES QUE SE ESCRIBIERON EN LA ESCENA PASADA
        NameP1.text = PlayerPrefs.GetString("P1Name").ToString();
        NameP2.text = PlayerPrefs.GetString("P2Name").ToString();

    }

    public void Update()
    {
        Winner();
    }

    //METODO PARA ACTUALIZAR LA PUNTUACION DEL P1
    public void GoalP1()
    {
        //SE SUMA POR CADA ANOTACION
        Score1++;
        
        //SE GUARDA ESE VALOR EN LOS PLAYERPREFS
        PlayerPrefs.SetInt("PointsP1", Score1);
        
        //COMPARTIMOS EL SCORE A LA UI
        ScoreP1.text = Score1.ToString();


    }

    //METODO PARA ACTUALIZAR LA PUNTUACION DEL P2
    public void GoalP2()
    {
        //SE SUMA POR CADA ANOTACION
        Score2++;

        //SE GUARDA ESE VALOR EN LOS PLAYERPREFS
        PlayerPrefs.SetInt("PointsP2", Score2);

        //COMPARTIMOS EL SCORE A LA UI
        ScoreP2.text = Score2.ToString();
    }

    //METODO PARA RESETEAR EL TABLERO POR CADA RONDA
    public void Restart()
    {
        //COLOCAR AL P1 EN SU POSICION INICIAL
        Player1.position = new Vector2(Player1.position.x, 0);

        //COLOCAR AL P2 EN SU POSICION INICIAL
        Player2.position = new Vector2(Player2.position.x, 0);

        //COLOCAR A LA PELOTA EN SU POSICION INICIAL
        Ball.position = new Vector2(0, 0);
    }

    //METODO PARA DETERMINAR GANADOR
    public void Winner()
    {

        //SI ALGUNOS DE LOS JUGADORES ALCANZA LA PUNTUACION MAXIMA SE CAMBIE DE ESCENA
        if(Score1 == 10 || Score2 == 10)
        {
            SceneManager.LoadScene(4);
        }

    }

}