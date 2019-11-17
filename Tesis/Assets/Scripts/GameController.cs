using System;
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
	public bool firstTime = false;
    public GameObject tutorialPosition;
	private int isNormalMode = 1;

    public void Start()
    {
		isNormalMode = PlayerPrefs.GetInt("isNormalMode", 1);
        currentPhase = phases[currentPhaseindex];
        firstTime = true;
    }

    public void FixedUpdate()
    {
		if((player.transform.position.x != pPosition.transform.position.x) && firstTime)
        {
			SetUpScene(currentPhase);
			firstTime = false;
        }
    }

    public void SetNextPhase()
	{
        currentPhaseindex++;
        if(currentPhaseindex == 3)
        {
            EndGame();
        }
        else
        {
            currentPhase = phases[currentPhaseindex];
            //SetUpScene(currentPhase);
        }

    }

    public void EndGame()
    {
        int repaired = 0;
        player.transform.position = new Vector3(tutorialPosition.transform.position.x, tutorialPosition.transform.position.y, tutorialPosition.transform.position.z);
        Debug.Log(player.transform.position);

        TextMeshProUGUI text = GameObject.Find("Canvas/Text(TMP)").GetComponent<TextMeshProUGUI>();
        GameObject[] totalLands = landController.lands;
        foreach(var land in totalLands)
        {
            if(land.tag == "SafeLand")
            {
                repaired++;
            }
        }
        double percentage = (repaired * 100) / totalLands.Length; 
        text.text = "Lograste reparar el " + percentage + "% de las tierras";
    }
    
	private void SetUpScene(string phase){
            switch (phase)
            {
                case "Ph":
			landController.initializePhLands(intToBool(isNormalMode));
                    break;
                case "Nutrients":
			landController.initializeNutrientsLands(intToBool(isNormalMode));
                    break;
                case "Farm":
			landController.initializeFarmLands(intToBool(isNormalMode));
                    break;
            }
	}


	private bool intToBool(int val)
	{
		if(val != 0)
			return true;
		else
			return false;
	}

  
}
