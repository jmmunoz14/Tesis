using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimNutrientsLandController : MonoBehaviour
{
    public int randomN;
    public Material[] materials;

    private bool enable = true;
    GameObject myText;
    public bool hasBeenSafe = false;
    public bool endNutSim = false;

    public List<GameObject> lands;
    private List<GameObject> landsTexts;
    // Start is called before the first frame update
    void Start()
    {
        GameObject text = new GameObject();
        text.transform.parent = transform;
        TextMeshPro t = text.AddComponent<TextMeshPro>();
        t.fontSize = 10;
        t.text = "Nutrir!";
        t.transform.localEulerAngles += new Vector3(180, 90, 180);
        t.transform.position += new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
        myText = text;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enable)
        {
            myText.SetActive(true);
        }
        if (hasBeenSafe)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.sharedMaterial = materials[3];
            gameObject.tag = "SafeNutrients";
            myText.SetActive(false);

        }
    }
    public void safeLand()
    {
        if (enable)
            hasBeenSafe = true;
    }
}
