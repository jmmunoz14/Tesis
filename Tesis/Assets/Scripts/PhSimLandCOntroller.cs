using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhSimLandCOntroller : MonoBehaviour
{
    public float optimalMinimunLevel = 35;
    public float optimalMaxLevel = 55;

    private float currentPhLevel;
    private TextMeshPro phText;
    public bool endSim1 = false;

    public Material[] materials;

    public bool isPhOK = false;

    void Start()
    {

        Renderer rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[0];
        gameObject.tag = "PlaneToRepair";
        currentPhLevel = Random.Range(1, 15);
        phText = gameObject.GetComponentInChildren<TextMeshPro>();
        phText.text = currentPhLevel + "Ph";
    }



    void FixedUpdate()
    {

        if (currentPhLevel > optimalMaxLevel)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.sharedMaterial = materials[2];
            gameObject.tag = "DamagedLand";
            phText = gameObject.GetComponentInChildren<TextMeshPro>();
            phText.text = currentPhLevel + "Ph";
            setPhState(false);
            endSim1 = true;
        }
        else if (currentPhLevel >= optimalMinimunLevel && currentPhLevel <= optimalMaxLevel)
        {
            gameObject.tag = "SafePH";
            Renderer rend = GetComponent<Renderer>();
            rend.sharedMaterial = materials[1];
            phText = gameObject.GetComponentInChildren<TextMeshPro>();
            phText.text = currentPhLevel + "Ph";
            setPhState(true);
            endSim1 = true;

        }
    }

    private void setPhState(bool state)
    {
        isPhOK = state;
    }

    public void increasePHLevel()
    {
        currentPhLevel += 0.01f * Random.Range(1, 25);
        phText.text = currentPhLevel + "Ph";

    }
}
