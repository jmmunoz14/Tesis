using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : MonoBehaviour
{
	public GameObject[] lands;
	public Material[] materials;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void initializePhLands()
	{
		foreach(var land in lands){
			PhLandController phlc = land.AddComponent<PhLandController>() as PhLandController;
			phlc.materials = materials;

		}
	}
}
