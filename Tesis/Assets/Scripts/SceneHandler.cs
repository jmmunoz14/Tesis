/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    private TextMeshProUGUI text;
    private TextMeshProUGUI textGameplay;
    private TextMeshProUGUI textPractice;

    private GameObject player;
    private int numberOfTutorial = 0;
    public int simulationsCompleted = 0;
    public TutorialController tutorialC;

    public GameObject gPosition;
    public GameObject practicePosition;

    void Awake()
    {
        text = GameObject.Find("TutorialSpace/Tutorial/Canvas/Text(TMP)").GetComponent<TextMeshProUGUI>();
        textGameplay = GameObject.Find("TutorialSpace/TutorialG/CanvasG/TextG").GetComponent<TextMeshProUGUI>();
        textPractice = GameObject.Find("TutorialSpace/TutorialJuego/CanvasJuego/TextP").GetComponent<TextMeshProUGUI>();

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
            textGameplay.text = "Al presionar una vez mas el gatillo, pasará a un último tutorial que le permitirá poner en práctica las mecánicas vistas aquí. Allí podrá " +
                                "simular las tareas que tendrá que realizar en el juego.";
        }
        if(numberOfTutorial == 7)
        {
            player.transform.position = new Vector3(practicePosition.transform.position.x, practicePosition.transform.position.y, practicePosition.transform.position.z);
        }
        if(numberOfTutorial == 8)
        {
            textPractice.text = "A su izquierda se encuenra un terreno similar a los que encontrará en el juego, y al frente un frasco, un balde y un vegetal. Cada uno correspondiente " + 
                                "a cada una de las etapas que deberá completar en el juego.";
        }
        if(numberOfTutorial == 9)
        {
            textPractice.text = "Comenzará con la primera fase. Para ello, tome el frasco transparente y vierta el líquido sobre la tierra " +
                                "hasta que su PH se encuentre entre 35 y 55. Cuando lo logre, apunte y presione el gatillo en esta dirección para continuar.";
			tutorialC.startSimulationPH();
        }

        if(numberOfTutorial == 10 && tutorialC.endPhSim)
        {
            textPractice.text = "Felicidades por completar la primera simulación. Para la siguiente simulación, recoja el balde y vierta el contenido en la tierra " +
                                "mientras el letrero de NUTRIR esté activo. Presione el gatillo una vez acabe";
            tutorialC.startSimulationNutrients();
        }
        else if(numberOfTutorial == 10 && !tutorialC.endPhSim)
        {
            textPractice.text = "Aún no ha terminado la simulación actual.";
            numberOfTutorial -= 1;
        }

        if(numberOfTutorial == 11 && tutorialC.endNutPhase)
        {
            textPractice.text = "Felicidades por completar la segunda simulación. Para la última etapa, recoja el vegetal y plántelo en la tierra dejandolo caer. Presione el gatillo al terminar";
            tutorialC.startSimulationFarm();
        }
        else if(numberOfTutorial == 11 && !tutorialC.endNutPhase)
        {
            textPractice.text = "Aún no ha terminado la simulación actual.";
            numberOfTutorial -= 1;
        }

        if(numberOfTutorial == 12 && tutorialC.endFarmPhase)
        {
            textPractice.text = "Felicidades, ha completado todas las pruebas. Se encuentra preparado para comenzar el juego.\n" +
                                "Al presionar el gatillo, será transportado y el juego comenzará. Muchos éxitos! ";
    
        }
        else if(numberOfTutorial == 12 && !tutorialC.endFarmPhase)
        {
            textPractice.text = "Aún no ha terminado la simulación actual.";
            numberOfTutorial -= 1;
        }

        if(numberOfTutorial == 13)
        {
			SceneManager.LoadScene("MainMenu");
        }


        numberOfTutorial += 1;
    }

}
