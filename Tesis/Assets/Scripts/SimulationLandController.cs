using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationLandController : MonoBehaviour
{
    public TutorialController  tutoController;
    public GameObject simulationLand;

    private PhSimLandCOntroller phlc;
    private SimNutrientsLandController nlc;
    private FarmSimLandController flc;

    public bool endSim1 = false;
    public bool endSim2 = false;
    public bool endSim3 = false;

    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        flc = simulationLand.GetComponent<FarmSimLandController>() as FarmSimLandController;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(phlc != null)
        {
            if (phlc.endSim1)
            {
                EndPhPhase();
            }
        }
        if(nlc != null)
        {
            if (nlc.endNutSim)
            {
                EndNutPhase();
            }
        }
        if(flc != null)
        {
            if (flc.finish)
            {
                EndFarmPhase();
            }
        }
    }


    public void initializePhLand()
    {
        phlc = simulationLand.AddComponent<PhSimLandCOntroller>();
        phlc.materials = materials;

        GameObject text = new GameObject();
        text.tag = "PhText";
        text.transform.parent = simulationLand.transform;

        TextMeshPro t = text.AddComponent<TextMeshPro>();
        t.fontSize = 10;
        t.transform.localEulerAngles += new Vector3(180, 90, 180);
        t.transform.position += new Vector3(simulationLand.transform.position.x, simulationLand.transform.position.y - 1f, simulationLand.transform.position.z);
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(3, 5);
    }

    private void EndPhPhase()
    {

        if (checkPhSafe())
        {
            endSim1 = true;
        }
        else
        {
            Destroy(simulationLand.GetComponent<PhSimLandCOntroller>());
            initializePhLand();
        }
    }
    public bool checkPhSafe()
    {

        if (simulationLand.tag == "SafePH")
        {
            return true;
        }
        return false;
    }
    public void initializeNutrients()
    {
        foreach (Transform child in simulationLand.transform)
        {
            if (child.tag != "Limit")
            {
                Destroy(child.gameObject);
            }
        }

        Destroy(simulationLand.GetComponent<PhSimLandCOntroller>());
        nlc = simulationLand.AddComponent<SimNutrientsLandController>() as SimNutrientsLandController;
        nlc.materials = materials;
    }
    public void EndNutPhase()
    {
       
        Destroy(simulationLand.GetComponent<NutrientLandController>());
        if (checkNutrientsSafe())
        {
            endSim2 = true;
        }
        else
        {
            nlc = simulationLand.AddComponent<SimNutrientsLandController>() as SimNutrientsLandController;
            initializeNutrients();
        }
    }
    public bool checkNutrientsSafe()
    {
        if (simulationLand.tag == "SafeNutrients")
        {
            return true;
        }
        return false;
    }
    public void initializeFarm()
    {
        foreach (Transform child in simulationLand.transform)
        {
            if (child.tag != "Limit")
            {
                Debug.Log(child.gameObject + "");
                Destroy(child.gameObject);
            }
        }
        Debug.Log("INICIALIZANDO CULTIVOS");
        flc = simulationLand.GetComponent<FarmSimLandController>();
        flc.materials = materials;


    }
    private void EndFarmPhase()
    {
        Destroy(simulationLand.GetComponent<FarmSimLandController>());
        if (checkFarmSafe())
        {
            endSim3 = true;
        }
        else
        {
            flc = simulationLand.AddComponent<FarmSimLandController>() as FarmSimLandController;
        }
    }
    public bool checkFarmSafe()
    {
        if (simulationLand.tag == "SafeLand")
        {
            return true;
        }
        return false;
    }
}
