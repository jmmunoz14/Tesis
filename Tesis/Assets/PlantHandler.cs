using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		FarmLandController x = collision.gameObject.GetComponent<FarmLandController>();
		x.plant();
	}
}
