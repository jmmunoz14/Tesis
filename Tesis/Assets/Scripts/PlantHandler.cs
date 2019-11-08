using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
    public FarmLandController.plantType plantOption;



    void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "SafeNutrients")
        {
            FarmLandController x = collision.gameObject.GetComponent<FarmLandController>();

            Debug.Log("PLANT OPTION" + plantOption);
            Debug.Log("X PLANT OPTION" + x.plantOption);
            if (plantOption == x.plantOption)
            {
                x.plant();
            }
            else
            {
                x.damageLand();
            }
        }


	}
}
