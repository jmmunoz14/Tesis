using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public GameObject menu;
	public GameObject credits;

	public void PlayNormalMode()
	{
		SceneManager.LoadScene("LandScene");
	}

	public void PlaySurvivalMode()
	{
		SceneManager.LoadScene("LandScene");
	}

	public void PlayTutorial()
	{
		SceneManager.LoadScene("Tutorial");
	}

	public void OpenCredits()
	{
		menu.SetActive(false);
		credits.SetActive(true);
	}

	public void CloseCredits()
	{
		credits.SetActive(false);
		menu.SetActive(true);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
