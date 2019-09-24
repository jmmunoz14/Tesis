/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public TextMeshProUGUI text;
    private GameObject player;
    private int numberOfTutorial = 0;

    void Awake()
    {
        text = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");

        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Button")
        {
            if(numberOfTutorial == 0)
            {
                text.text = "El proceso de reparar un suelo generalmente consta de 3 partes: \n" +
                            "- Recuperar la acidez del suelo. \n" +
                            "- Devolver los nutrientes del suelo. \n" +
                            "- Generar rotación de cultivos.";
            }
            if(numberOfTutorial == 1)
            {
                text.text = "El dia de hoy tomará el papel de un campesino que debe recuperar y reparar su suelo, lo cual no es una tarea facil. \n" +
                            "El objetivo es entender el proceso que se lleva a cabo, la dificultad de este proceso y como en muchos casos el suelo es irreparable.";
            }
            if(numberOfTutorial == 2)
            {
                text.text = "Usted deberá realizar cada una de las tres tareas y tendrá un tiempo límite. Al presionar OK, comenzará el tiempo de la primera tarea";
            }
            Debug.Log("Button was clicked");
        }
        if(numberOfTutorial == 3)
        {
            player.transform.position = new Vector3((float)23.141, 0, (float)-27.237);
        }

        numberOfTutorial += 1;
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Button")
        {
            numberOfTutorial += 1;
            text.text = "Cambio";
            Debug.Log("Button was entered");
        }
        if (numberOfTutorial == 3)
        {
            player.transform.position = new Vector3((float)23.141, 0, (float)-27.237);
        }
    }
}
