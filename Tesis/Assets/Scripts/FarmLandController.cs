using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandController : MonoBehaviour
{
    public enum plantType {zanahoria, maiz, tomate}
    public plantType plantOption;
    public GameObject plantedPlant;
	private GameObject child;
    private bool alreadyPlanted = false;
	private int numberOfElements = 6;
    public Material[] materials;
 

	public void plant()
	{
        if(!alreadyPlanted)
        {
            Vector3 center = transform.position;
            for (int i = 0; i < numberOfElements; i++)
            {
                Vector3 pos = RandomCircle(center, 2f);
                child = Instantiate(plantedPlant, pos, Quaternion.Euler(0, 0, 0));
                child.transform.parent = transform;
            }
            gameObject.tag = "SafeLand";
            Renderer rend = GetComponent<Renderer>();
            rend.sharedMaterial = materials[0];
            alreadyPlanted = true;
        }

	}
		
    public void damageLand()
    {
        gameObject.tag = "DamagedLand";
        Renderer rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[1];

    }


	Vector3 RandomCircle (Vector3 center, float radius  ){
		float angx = Random.Range(-2f,2f);
		float angy = Random.Range(-2f,2f);
		Vector3 pos;
		pos.x = center.x + angx;
		pos.y = center.y;
		pos.z = center.z + angy;
		return pos;
	}

}
