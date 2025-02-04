﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NutrientLandController : MonoBehaviour
{
    public int randomN;
	public Material[] materials;
    private bool enable = false;
    private float timeToDie = 7f;
    GameObject myText;
	public bool hasBeenSafe = false;
    public bool end = false;

    public List<GameObject> lands;
    private List<GameObject> landsTexts;
	private int isNormalMode;
   

    void Start()
    {
        GameObject text = new GameObject();
		text.tag = "NutrientText";
        text.transform.parent = transform;
        TextMeshPro t = text.AddComponent<TextMeshPro>();
        t.fontSize = 10;
        t.text = "Nutrir!";
        t.transform.localEulerAngles += new Vector3(180, 90, 180);
        t.transform.position += new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
        text.SetActive(false);
        myText = text;

		isNormalMode = PlayerPrefs.GetInt("isNormalMode", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enable & timeToDie > 0)
        {
            myText.SetActive(true);
            timeToDie -= Time.deltaTime;
        }

		if (timeToDie <= 0 && (isNormalMode == 0))
        {
            enable = false;
            myText.SetActive(false);
            timeToDie = 7f;
            end = true;
        }

		if(hasBeenSafe)
		{
			Renderer rend = GetComponent<Renderer>();
			rend.sharedMaterial = materials[3];
			gameObject.tag = "SafeNutrients";
            
		}
    }

    public void EnableText()
    {
        enable = true;
    }

	public void safeLand()
	{
        if(enable)
		hasBeenSafe = true;
	}

    
}
