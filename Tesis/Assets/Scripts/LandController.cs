using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : MonoBehaviour
{
	public GameObject[] lands;
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
			land.AddComponent<PhLandController>();
		}
	}
}
