using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class land : MonoBehaviour
{
    // Start is called before the first frame update
    private int gamePhase = 2;
    private static bool disabled;
    private GameObject[] landsTexts;
    private GameObject[] lands;

    private float timeToShow = 4f;
    private float timeToDie = 5f;
    void Start()
    {
        lands = GameObject.FindGameObjectsWithTag("PlaneToRepair");
        foreach(var land in lands)
        {
            GameObject text = new GameObject();

            TextMeshPro t = text.AddComponent<TextMeshPro>();
            int random = RandomNumber(1, 15);
            t.name = land.name + "text";
            t.text = random + " PH";
            t.fontSize = 10;

            text.tag = "TextGame";
            t.transform.localEulerAngles += new Vector3(180, 90, 180);
            t.transform.localPosition += new Vector3(land.transform.position.x, land.transform.position.y - 1f, land.transform.position.z + 9f);

        }

        landsTexts = GameObject.FindGameObjectsWithTag("TextGame");

        disabled = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePhase == 2)
        {
            if (disabled)
            {
                foreach (var landText in landsTexts)
                {
                    landText.SetActive(false);
                }
                disabled = false;

            }
            else
            {
                AlternateTexts();
            }
        }
    }

    private void AlternateTexts()
    {
            timeToShow -= Time.deltaTime;
            if (timeToShow < 0)
            {
                int random = RandomNumber(1, 14);
                Debug.Log("Show "+ landsTexts[random].name);
                landsTexts[random].SetActive(true);
                landsTexts[random].GetComponent<TextMeshPro>().text = "Nutrir!";
                timeToShow = 2f;
            }
            timeToDie -= Time.deltaTime;

            if (timeToDie <= 0)
            {
                int random = RandomNumber(1, 14);
                Debug.Log("Hide " + random);
                landsTexts[random].SetActive(false);
                timeToDie = 5f;
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if(gamePhase == 1)
        {
            Debug.Log("Object is inside the trigger");

            gamePhase = 2;
        }
        else if(gamePhase == 2)
        {

        }
    }

    int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
