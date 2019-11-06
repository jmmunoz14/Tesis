using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class LandController : MonoBehaviour
{
    public GameController gameController;
	public GameObject[] lands;

    public GameObject simLand;
    private PhLandController simph;
    public NutrientLandController nlc;
    public FarmLandController farmSim;
    public bool oksim1 = false;
    public bool oksim2 = false;
    public bool oksim3 = false;

    public Material[] materials;

    public List<GameObject> landsToNutrient = new List<GameObject>();
    public List<GameObject> landsToFarm = new List<GameObject>();

    public float nutrientsTimeToShow;


    private bool phRunning = false;
    private bool nutrientsRunning = false;
    private bool farmRunning = false;

    public float phTimer;
    public float nutrientsTimer;
    public float farmTimer;

    public Text izquierdo;
    public Text derecho;

    public List<int> num = new List<int>();


    private void Start()
    {
        simLand = GameObject.Find("TutorialJuego/simLand");
        simph = simLand.GetComponent<PhLandController>() as PhLandController;
        nlc = simLand.AddComponent<NutrientLandController>() as NutrientLandController;
        farmSim = simLand.GetComponent<FarmLandController>() as FarmLandController;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oksim1 = simph.isPhOK;
        if (simph.endSim1)
        {
            EndSimPhPhase();
        }
        oksim2 = nlc.hasBeenSafe;
        if (nlc.end)
        {
            EndSimNutrientsPhase();
        }
        oksim3 = farmSim.isOk;
        if (farmSim.finish)
        {
            EndSimFarmPhase();
        }

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
            izquierdo.transform.gameObject.SetActive(true);
            derecho.transform.gameObject.SetActive(true);
            nutrientsTimer -= Time.deltaTime;
            izquierdo.text = nutrientsTimer + " S";
            derecho.text = nutrientsTimer + " S";
            if (nutrientsTimer <= 0.0f)
            {
                izquierdo.transform.gameObject.SetActive(false);
                derecho.transform.gameObject.SetActive(false);
                nutrientsRunning = false;
                EndNutrientsPhase();
            }
            nutrientsTimeToShow -= Time.deltaTime;
            if (nutrientsTimeToShow < 0.0f)
            {
				int r = Random.Range (0, num.Count);
                landsToNutrient[num[r]].GetComponent<NutrientLandController>().EnableText();
				num.RemoveAt(r);
                nutrientsTimeToShow = 2f;
            }
        }

        if(farmRunning)
        {
            izquierdo.transform.gameObject.SetActive(true);
            derecho.transform.gameObject.SetActive(true);
            farmTimer -= Time.deltaTime;
            izquierdo.text = farmTimer + " S";
            derecho.text = farmTimer + " S";
            if (farmTimer <= 0.0f)
            {
                izquierdo.transform.gameObject.SetActive(false);
                derecho.transform.gameObject.SetActive(false);
                farmRunning = false;
                EndFarmPhase();
            }
        }

    }

    public void initializeSimFarmLands()
    {
        simLand.tag = "SafeNutrients";
    }

    public void initializeSimNutrientsLands()
    {
        nlc.materials = materials;
        simLand.GetComponent<NutrientLandController>().EnableText();
    }

    public void initializeSimPhLand()
    {
        simph.materials = materials;

        GameObject text = new GameObject();
        text.tag = "PhText";
        text.transform.parent = simLand.transform;

        TextMeshPro t = text.AddComponent<TextMeshPro>();
        t.fontSize = 10;
        t.transform.localEulerAngles += new Vector3(180, 90, 180);
        t.transform.position += new Vector3(simLand.transform.position.x, simLand.transform.position.y - 1f, simLand.transform.position.z);
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(3, 5);
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
		int nutrientsCounter = 0;
        foreach (var land in lands)
        {
            if (land.tag == "SafePH") {
                landsToNutrient.Add(land);
            }
        }
        foreach (var land in landsToNutrient)
        {
            NutrientLandController nlc = land.AddComponent<NutrientLandController>() as NutrientLandController;
            nlc.materials = materials;
            num.Add(nutrientsCounter);
            nutrientsCounter++;
        }
        nutrientsRunning = true;
            
        
    }

    public void initializeFarmLands()
    {
        foreach (var land in lands)
        {
            if (land.tag == "SafeNutrients")
            {
                landsToFarm.Add(land);
            }
        }
        if (landsToFarm.Count == 0)
        {
            gameController.EndGame();
        }
        else
        {
            farmRunning = true;
        }
    }
    public void EndSimPhPhase()
    {
        Destroy(simLand.GetComponent<PhLandController>());
        foreach (Transform child in simLand.transform)
        {
            if (child.tag != "Limit")
            {
                Destroy(child.gameObject);
            }
        }
        if (!oksim1)
        {
            simph = simLand.AddComponent<PhLandController>() as PhLandController;
            initializeSimPhLand();
        }
        
    }

    public void EndPhPhase()
    {
        foreach (var land in lands)
        {
            Destroy(land.GetComponent<PhLandController>());
            foreach (Transform child in land.transform)
            {
                if(child.tag != "Limit")
                {
                    Destroy(child.gameObject);
                }
            }

        }
        if (checkPhSafe())
        {
            gameController.player.transform.position = new Vector3(gameController.pPosition.transform.position.x, gameController.pPosition.transform.position.y, gameController.pPosition.transform.position.z);
            gameController.SetNextPhase();
            gameController.firstTime = true;
        } else
        {
            gameController.EndGame();
        }
    }
    public bool checkPhSafe()
    {
        foreach (var land in lands)
        {
            if (land.tag == "SafePH")
            {
                return true;
            }
        }
        return false;
    }

    public void EndSimNutrientsPhase()
    {
        Destroy(simLand.GetComponent<NutrientLandController>());
        foreach (Transform child in simLand.transform)
        {
            if (child.tag != "Limit")
            {
                Destroy(child.gameObject);
            }
        }

        if (!oksim2)
        {
            nlc = simLand.AddComponent<NutrientLandController>() as NutrientLandController;
            initializeSimNutrientsLands();
        }
    }
    public void EndNutrientsPhase()
    {
        foreach (var land in landsToNutrient)
        {
            Destroy(land.GetComponent<NutrientLandController>());
            foreach (Transform child in land.transform)
            {
                if (child.tag != "Limit")
                {
                    Destroy(child.gameObject);
                }
            }

        }
        if (checkNutrientsSafe())
        {
            gameController.player.transform.position = new Vector3(gameController.pPosition.transform.position.x, gameController.pPosition.transform.position.y, gameController.pPosition.transform.position.z);
            gameController.SetNextPhase();

            gameController.firstTime = true;
        }
        else
        {
            gameController.EndGame();
        }
    }

    public bool checkNutrientsSafe()
    {
        foreach (var land in lands)
        {
            if (land.tag == "SafeNutrients")
            {
                return true;
            }
        }
        return false;
    }

    public void EndSimFarmPhase()
{
        Destroy(simLand.GetComponent<FarmLandController>());
        foreach (Transform child in simLand.transform)
        {
            if (child.tag != "Limit")
            {
                Destroy(child.gameObject);
            }
        }

        if (!oksim3)
        {
            farmSim = simLand.AddComponent<FarmLandController>() as FarmLandController;
            initializeSimFarmLands();
        }

    }

    public void EndFarmPhase()
    {
        foreach (var land in landsToFarm)
        {
            if(land.gameObject.tag!="SafeLand")
            {
                land.gameObject.tag = "DamagedLand";
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
