using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
	

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
		SceneManager.LoadScene("MainMenu");	
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
