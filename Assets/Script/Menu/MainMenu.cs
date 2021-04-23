using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	private void Start()
	{
	}
	public void playGame()
	{
		SceneManager.LoadScene(1);

	}
	
	public void quitGame()
	{
		Debug.Log("QUIT GAME !");
		Application.Quit();
	}
}
