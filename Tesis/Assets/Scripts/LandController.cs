using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using TMPro;
using UnityEngine.UI;

public class LandController : MonoBehaviour
{
    public GameController gameController;
	public GameObject[] lands;
	public Material[] materials;
    List<GameObject> landsToNutrient = new List<GameObject>();
    public float nutrientsTimeToShow = 8f;

    private bool phRunning = false;
    private bool nutrientsRunning = false;
    public float phTimer;
    public float nutrientsTimer;
    public float farmTimer;
    public Text izquierdo;
    public Text derecho;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (phRunning)
        {
            phTimer -= Time.deltaTime;
            izquierdo.text = phTimer + " S";
            derecho.text = phTimer + " S";
            if (phTimer <= 0.0f)
            {
                izquierdo.transform.gameObject.SetActive(false);
                derecho.transform.gameObject.SetActive(false);
                phRunning = false;
                EndPhPhase();
            }

        }

        if (nutrientsRunning)
        {
            nutrientsTimer -= Time.deltaTime;
            izquierdo.text = phTimer + " S";
            derecho.text = phTimer + " S";
            if (nutrientsTimer <= 0.0f)
            {
                izquierdo.transform.gameObject.SetActive(false);
                derecho.transform.gameObject.SetActive(false);
                nutrientsRunning = false;
                EndNutrientsPhase();
            }
            nutrientsTimeToShow -= Time.deltaTime;
            if (nutrientsTimeToShow < 0)
            {
                int r = RandomNumber(1, 14);
                landsToNutrient[r].GetComponent<NutrientLandController>().EnableText();
                nutrientsTimeToShow = 4f;
            }
        }

    }

	public void initializePhLands()
	{
		foreach(var land in lands){
			PhLandController phlc = land.AddComponent<PhLandController>() as PhLandController;
			phlc.materials = materials;

            GameObject text = new GameObject();
            text.tag = "PhText";
            text.transform.parent = land.transform;

            TextMeshPro t = text.AddComponent<TextMeshPro>();
            t.fontSize = 10;
            t.transform.localEulerAngles += new Vector3(180, 90, 180);
            t.transform.position += new Vector3(land.transform.position.x, land.transform.position.y - 1f, land.transform.position.z);
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(3, 5);
        }
        phRunning = true;
        izquierdo.transform.gameObject.SetActive(true);
        derecho.transform.gameObject.SetActive(true);

    }

    public void initializeNutrientsLands()
    {
        foreach (var land in lands)
        {
            if (land.tag == "SafeLand") {
                landsToNutrient.Add(land);
            }
        }

        foreach (var land in landsToNutrient)
        {
            NutrientLandController nlc = land.AddComponent<NutrientLandController>() as NutrientLandController;
        }
        nutrientsRunning = true;

    }



    public void EndPhPhase()
    {
        foreach (var land in lands)
        {
            Destroy(land.GetComponent<PhLandController>());
            foreach (Transform child in land.transform)
            {
                Destroy(child.gameObject);
            }

        }
        gameController.SetNextPhase();
    }


    public void EndNutrientsPhase()
    {
        foreach (var land in landsToNutrient)
        {
            Destroy(land.GetComponent<NutrientLandController>());
            foreach (Transform child in land.transform)
            {
                Destroy(child.gameObject);
            }

        }
        gameController.SetNextPhase();
    }

    int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
