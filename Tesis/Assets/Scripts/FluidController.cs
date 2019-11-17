using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class FluidController : MonoBehaviour
{

	public GameObject flash;
    public ObiEmitter component;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Euler: " + flash.gameObject.transform.eulerAngles.x);
        if (flash.gameObject.transform.eulerAngles.x <= 90)
        {
            component.speed = 1f;
        }
        else
        {
            component.speed = 0f;
        }
    }
}
