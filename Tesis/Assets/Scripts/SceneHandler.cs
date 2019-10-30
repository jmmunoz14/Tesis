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
    private TextMeshProUGUI textGameplay;
    private GameObject player;
    private int numberOfTutorial = 0;
    public GameController gameControl;

    public GameObject pPosition;
    public GameObject gPosition;

    void Awake()
    {
        text = GameObject.Find("Canvas/Text(TMP)").GetComponent<TextMeshProUGUI>();
        textGameplay = GameObject.Find("TutorialG/CanvasG/TextG").GetComponent<TextMeshProUGUI>();

        player = GameObject.Find("Player");
        
       laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        
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
                            "El objetivo es entender el proceso que se lleva a cabo, la dificultad de este proceso y como, en muchos casos, el suelo es irreparable.";
            }
            if (numberOfTutorial == 2)
            {
                text.text = "Usted deberá realizar cada una de las tres tareas y tendrá un tiempo límite. Al presionar el gatillo, pasará a un tutorial de Gameplay";
            }
        }
        if (numberOfTutorial == 3)
        {
            player.transform.position = new Vector3(gPosition.transform.position.x, gPosition.transform.position.y, gPosition.transform.position.z);
       

        }
        if(numberOfTutorial == 4)
        {
            textGameplay.text = "En primer lugar, para moverse presione cualquiera de las dos palancas mientras apunta con el brazo en " +
                                "la dirección deseada. Cuando vea un circulo verde, deje presionar la palanca y el personaje se transportará a esa posición. ";

        }
        if(numberOfTutorial == 5)
        {
            textGameplay.text = "Para interactuar con los objetos, acerce su mano hasta que al objeto le aparezca un borde amarillo y mantenga presionado " +
                                "el botón que se encuentra en la parte de abajo de cualquier control junto a su dedo medio. Al momento de dejar de presionar " +
                                "el botón, se soltará el objeto. ";
        }
        if(numberOfTutorial == 6)
        {
            textGameplay.text = "Al presionar una vez mas el gatillo, el juego comenzará. Tómese un tiempo para familiarizarse con los controles y " +
                                "las interacciones antes de comenzar. Cuando se sienta preparado presione el gatillo.";
        }
        if(numberOfTutorial == 7)
        {
            player.transform.position = new Vector3(pPosition.transform.position.x, pPosition.transform.position.y, pPosition.transform.position.z);
            gameControl.StartGame();
        }

        numberOfTutorial += 1;
    }

}
