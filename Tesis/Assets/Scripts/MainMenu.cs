using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public GameObject menu;
	public GameObject credits;
	private int isNormalMode = 1;

	public void PlayNormalMode()
	{
		isNormalMode = 1;
		saveData(isNormalMode);
		SceneManager.LoadScene("LandScene");
	}

	public void PlaySurvivalMode()
	{
		isNormalMode = 0;
		saveData(isNormalMode);
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

	void saveData(int normalMode)
	{
		PlayerPrefs.SetInt("isNormalMode", normalMode);
	}
		
}
