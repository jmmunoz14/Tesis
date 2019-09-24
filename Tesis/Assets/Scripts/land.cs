using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class land : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject text = new GameObject();
        TextMeshPro t = text.AddComponent<TextMeshPro>();
        System.Random rnd = new System.Random();
        int number = rnd.Next(1, 15);
        t.name = gameObject.name + "text";
        t.text = number + " PH";
        t.fontSize = 10;

        t.transform.localEulerAngles += new Vector3(180, 90, 180);
        t.transform.localPosition += new Vector3( gameObject.transform.position.x , gameObject.transform.position.y - 1f, gameObject.transform.position.z + 9f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is inside the trigger");
    }
}
