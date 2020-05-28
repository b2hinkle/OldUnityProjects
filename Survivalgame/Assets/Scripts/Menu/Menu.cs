using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void StartButton(string newGameLevel)
	{
		SceneManager.LoadScene(newGameLevel);
	}

	public void QuitButton()
	{
		Application.Quit();
	}

	
}
