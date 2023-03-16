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
