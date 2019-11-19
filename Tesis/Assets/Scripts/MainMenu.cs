using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public GameObject menuLeft;
	public GameObject creditsLeft;
	public GameObject menuRight;
	public GameObject creditsRight;
	public GameObject player;
	private int isNormalMode = 1;

	public void PlayNormalMode()
	{
		isNormalMode = 1;
		saveData(isNormalMode);
		Destroy(player);
		SceneManager.LoadScene("LandScene");
	}

	public void PlaySurvivalMode()
	{
		isNormalMode = 0;
		saveData(isNormalMode);
		Destroy(player);
		SceneManager.LoadScene("LandScene");
	}

	public void PlayTutorial()
	{
		Destroy(player);
		SceneManager.LoadScene("Tutorial");
	}

	public void OpenCredits()
	{
		menuLeft.SetActive(false);
		menuRight.SetActive(false);
		creditsLeft.SetActive(true);
		creditsRight.SetActive(true);
	}

	public void CloseCredits()
	{
		menuLeft.SetActive(true);
		menuRight.SetActive(true);
		creditsLeft.SetActive(false);
		creditsRight.SetActive(false);
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
