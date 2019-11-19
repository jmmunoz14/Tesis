using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MenuVRHandler : MonoBehaviour
{
	public SteamVR_LaserPointer laserPointer;
    public GameObject playerM;
	public Button normalMode;
	public Button survivalMode;
	public Button tutorialMode;
	public Button exitButton;
	public Button creditsButton;
	public Button menuButton;

	void Awake()
	{
		laserPointer.PointerClick += PointerClick;
	}

	public void PointerClick(object sender, PointerEventArgs e)
	{
		switch(e.target.name)
		{
		case "NormalButton":
                normalMode.onClick.Invoke();
			break;

		case "SurvivalButton":
                survivalMode.onClick.Invoke();
			break;

		case "Tutorial":
                Destroy(playerM);
                tutorialMode.onClick.Invoke();
			break;

		case "ExitGame":
			exitButton.onClick.Invoke();
			break;

		case "Credits":
			creditsButton.onClick.Invoke();
			break;

		case "MenuButton":
			menuButton.onClick.Invoke();
			break;

		default:
			break;

		}
	}
}
