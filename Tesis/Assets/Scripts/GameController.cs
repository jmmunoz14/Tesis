using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int currentPhaseindex = 0;
	public string[] phases;
	public string currentPhase;
	public LandController landController;

    public void StartGame()
    {
        currentPhase = phases[currentPhaseindex];
        SetUpScene(currentPhase);
    }
			
	public void SetNextPhase()
	{
        currentPhaseindex++;
		currentPhase = phases[currentPhaseindex];
		SetUpScene(currentPhase);
		
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
