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
    private TextMeshProUGUI text;
    private GameObject player;
    private int numberOfTutorial = 0;
    public GameController gameControl;

    public GameObject pPosition;
    public GameObject gPosition;

    void Awake()
    {
        text = GameObject.Find("Canvas/Text(TMP)").GetComponent<TextMeshProUGUI>();
        Debug.Log(text);
        player = GameObject.Find("Player");
        
       laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log(e.target.name);

        if (e.target.name == "Plane (1)")
        {
            if (numberOfTutorial == 0)
            {
                text.text = "El proceso de reparar un suelo generalmente consta de 3 partes: \n" +
                            "- Recuperar la acidez del suelo. \n" +
                            "- Devolver los nutrientes del suelo. \n" +
                            "- Generar rotación de cultivos.";
            }
            if (numberOfTutorial == 1)
            {
                text.text = "El dia de hoy tomará el papel de un campesino que debe recuperar y reparar su suelo, lo cual no es una tarea facil. \n" +
                            "El objetivo es entender el proceso que se lleva a cabo, la dificultad de este proceso y como en muchos casos el suelo es irreparable.";
            }
            if (numberOfTutorial == 2)
            {
                text.text = "Usted deberá realizar cada una de las tres tareas y tendrá un tiempo límite. Al presionar el gatillo, comenzará el tiempo de la primera tarea";
            }
            Debug.Log("Button was clicked");
        }
        if (numberOfTutorial == 3)
        {
            player.transform.position = new Vector3(gPosition.transform.position.x, gPosition.transform.position.y, gPosition.transform.position.z);
       

        }
        if(numberOfTutorial == 4)
        {
            player.transform.position = new Vector3(pPosition.transform.position.x, pPosition.transform.position.y, pPosition.transform.position.z);
            gameControl.StartGame();

        }

        numberOfTutorial += 1;
    }

}
