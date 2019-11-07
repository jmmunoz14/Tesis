using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimPlantHandler : MonoBehaviour
{
    public FarmSimLandController.plantType plantOption;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SafeNutrients")
        {
            FarmSimLandController x = collision.gameObject.GetComponent<FarmSimLandController>();
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
