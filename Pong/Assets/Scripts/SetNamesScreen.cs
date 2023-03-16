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
