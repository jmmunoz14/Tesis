using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BucketIndicator : MonoBehaviour
{
    public GameObject[] lands;
    public static bool disabled;
    public float tiempo = 7f;
    public float tiempoD = 5f;
    private GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        disabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        {
            foreach (var land in lands)
            {
                text = GameObject.Find(land.name + "text");
                text.SetActive(false);
            }
            disabled = false;

        }
        else
        {
            tiempo -= Time.deltaTime;
            if (tiempo < 0)
            {
                int random = RandomNumber(0, 4);
                text = GameObject.Find(lands[random].name + "text");
                text.SetActive(true);
                tiempo = 7f;
            }
            tiempoD -= Time.deltaTime;

            if (tiempoD <= 0)
            {
                int random = RandomNumber(0, 4);
                text = GameObject.Find(lands[random].name + "text");
                text.SetActive(false);
                tiempoD = 5f;
            }
        }



    }

    int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }


}

