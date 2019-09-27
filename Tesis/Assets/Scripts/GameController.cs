using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int currentPhaseindex = 0;
	public string[] phases;
	public string currentPhase;
	public LandController landController;
    public GameObject player;
    public GameObject pPosition;
    public GameObject tutorialPosition;

    public void StartGame()
    {
        currentPhase = phases[currentPhaseindex];
        SetUpScene(currentPhase);
    }
			
	public void SetNextPhase()
	{
        currentPhaseindex++;
        if(currentPhaseindex == 2)
        {
            EndGame();
        }
        else
        {
            currentPhase = phases[currentPhaseindex];
            SetUpScene(currentPhase);
            player.transform.position = new Vector3(pPosition.transform.position.x, pPosition.transform.position.y, pPosition.transform.position.z);

        }

    }

    public void EndGame()
    {
        player.transform.position = new Vector3(tutorialPosition.transform.position.x, tutorialPosition.transform.position.y, tutorialPosition.transform.position.z);
       TextMeshProUGUI text = GameObject.Find("Canvas/Text(TMP)").GetComponent<TextMeshProUGUI>();
        GameObject[] totalLands = landController.lands;
        List<GameObject> landsRepaired = landController.landsToNutrient;
        double percentage = (landsRepaired.Count * 100) / totalLands.Length; 
        text.text = "Lograste reparar el " + percentage + " de las tierras";
    }
    
	private void SetUpScene(string phase){
		switch(phase)
		{
		case "Ph":
			landController.initializePhLands();
		break;
		case "Nutrients":
                landController.initializeNutrientsLands();
                break;
		case "Farm":
			break;
			default:
			break;
		}
	}

}
