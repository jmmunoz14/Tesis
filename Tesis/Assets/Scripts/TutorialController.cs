using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    private int currentPhaseindex = 0;
    public string[] phases;
    public string currentPhase;

    public bool endPhSim = false;
    public bool endNutPhase = false;
    public bool endFarmPhase = false;

    public SimulationLandController landController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endPhSim = landController.checkPhSafe();
        endNutPhase = landController.checkNutrientsSafe();
        endFarmPhase = landController.checkFarmSafe();
    }

    public void startSimulationPH()
    {
        currentPhase = phases[currentPhaseindex];
        SetUpScene(currentPhase);
    }
    public void startSimulationNutrients()
    {
        currentPhaseindex++;
        currentPhase = phases[currentPhaseindex];
        SetUpScene(currentPhase);
    }
    public void startSimulationFarm()
    {
        currentPhaseindex++;
        currentPhase = phases[currentPhaseindex];
        SetUpScene(currentPhase);
    }
    private void SetUpScene(string phase)
    {
        switch (phase)
        {
            case "Ph":
                landController.initializePhLand();
                break;
            case "Nutrients":
                landController.initializeNutrients();
                break;
            case "Farm":
                landController.initializeFarm();
                break;
        }
    }

}
