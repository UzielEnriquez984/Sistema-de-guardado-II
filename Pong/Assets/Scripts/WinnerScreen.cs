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

}
