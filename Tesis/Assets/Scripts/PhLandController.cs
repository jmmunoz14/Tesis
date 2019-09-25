using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhLandController : MonoBehaviour
{
	[Range(22f,32f)]
	public float optimalLevel;  

	private float currentPhLevel;

	public Material[] materials;

	public bool isPhOK = false;
		
    void Start()
    {
		currentPhLevel = Random.Range(1f, 15f);
    }

    
    void FixedUpdate(){
		if(currentPhLevel>optimalLevel)
		{
			Renderer rend = GetComponent<Renderer>();
			rend.sharedMaterial = materials[0];
		}
    }

	private void setPhState(bool state)
	{
		isPhOK = state;
	}

	public void increasePHLevel()
	{
		currentPhLevel += 1*Random.Range(0.5f,1.2f);
	}
}
