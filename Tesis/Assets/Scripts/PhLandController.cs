using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhLandController : MonoBehaviour
{

	public float optimalMinimunLevel = 7;
    public float optimalMaxLevel = 8;

    private float currentPhLevel;
    private TextMeshPro phText;

	public Material[] materials;

	public bool isPhOK = false;
		
    void Start()
    {
		currentPhLevel = Random.Range(0, 6);
        phText = GetComponentInChildren<TextMeshPro>();
        phText.text = currentPhLevel + "Ph";
    }


    void FixedUpdate() {
		if (currentPhLevel > optimalMaxLevel)
			{
			Renderer rend = GetComponent<Renderer>();
					rend.sharedMaterial = materials[2];
					gameObject.tag = "DamagedLand";
					setPhState(false);
				}
			else if (currentPhLevel >= optimalMinimunLevel && currentPhLevel <= optimalMaxLevel)
			{
				gameObject.tag = "SafePH";
				Renderer rend = GetComponent<Renderer>();
				rend.sharedMaterial = materials[1];
				setPhState(true);
			}

    }

	private void setPhState(bool state)
	{
		isPhOK = state;
	}

	public void increasePHLevel()
	{
		currentPhLevel += 0.01f*Random.Range(0.15f,0.50f);
        phText.text = currentPhLevel + "Ph";
        
	}
}
