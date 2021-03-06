using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	private void Start()
	{
		GameIsPaused = false;
		Time.timeScale = 1f;

	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (GameIsPaused)
			{
                resume();
			} else 
			{
                pause();
			}
		}
    }

    public void resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;

	}
}
