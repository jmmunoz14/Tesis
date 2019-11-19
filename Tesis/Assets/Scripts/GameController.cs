using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int currentPhaseindex = 0;
	public string[] phases;
	public string currentPhase;
	public LandController landController;
    public GameObject player;
    public GameObject pPosition;
	public bool firstTime = false;
    public TextMeshProUGUI safeLeftText;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI safeRightText;
    public TextMeshProUGUI timeRightText;
    public Canvas endGameCanvasLeft;
    public Canvas endGameCanvasRight;
    private int isNormalMode;
    public float normalTimer=0f;
    private bool isPlaying = false;

    public void Start()
	{
		isNormalMode = PlayerPrefs.GetInt("isNormalMode", 1);
        currentPhase = phases[currentPhaseindex];
        firstTime = true;
    }

    public void FixedUpdate()
    {
        if (isNormalMode == 1 && isPlaying)
        {
            normalTimer += Time.deltaTime;
        }
     
        if ((player.transform.position.x != pPosition.transform.position.x) && firstTime)
        {
			SetUpScene(currentPhase);
			firstTime = false;
            isPlaying = true;
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
        }

    }

    public void EndGame()
    {
        isPlaying = false;
        int repaired = 0;
        GameObject[] totalLands = landController.lands;
        foreach(var land in totalLands)
        {
            if(land.tag == "SafeLand")
            {
                repaired++;
            }
        }
        double percentage = (repaired * 100) / totalLands.Length; 
        safeLeftText.text = "Lograste reparar el " + percentage + "% de las tierras";
        safeRightText.text = "Lograste reparar el " + percentage + "% de las tierras";

        if (isNormalMode == 1)
        {
            timeLeftText.text = "Tu tiempo fue de " + normalTimer + " SEGUNDOS.";
            timeRightText.text = "Tu tiempo fue de " + normalTimer + " SEGUNDOS.";
        }
        Debug.Log("END");
        endGameCanvasLeft.gameObject.SetActive(true);
        endGameCanvasRight.gameObject.SetActive(true);
    }
    
	private void SetUpScene(string phase){
            switch (phase)
            {
                case "Ph":
			landController.initializePhLands(intToBool(isNormalMode));
                    break;
                case "Nutrients":
			landController.initializeNutrientsLands();
                    break;
                case "Farm":
			landController.initializeFarmLands();
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
