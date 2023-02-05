using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
	private bool firstTime = true;
	private void Start()
	{
		if (firstTime)
		{
			//goMainMenu();
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			QuitGame();
		} 
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			ReplayGame();
		}
    }
	
	public void ReplayGame()
	{
		SceneManager.LoadScene("MainScene");
	}
	
	public void goMainMenu()
	{
		firstTime = false;
		SceneManager.LoadScene("MainMenu");	
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
