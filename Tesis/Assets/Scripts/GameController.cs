using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public string[] phases;
	public string currentPhase;
	public LandController landController;

    private void Start()
    {
		currentPhase = phases[0];
		SetUpScene(currentPhase);
    }
			
	public void SetNextPhase(string nextPhase)
	{
		currentPhase = nextPhase;
		SetUpScene(currentPhase);
		
	}

	private void SetUpScene(string phase){
		switch(phase)
		{
		case "Ph":
			landController.initializePhLands();
		break;
		case "Nutrients":
			break;
		case "Farm":
			break;
			default:
			break;
		}
	}

}
