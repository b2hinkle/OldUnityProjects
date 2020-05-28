using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
	public void StartButton(string newGameLevel)
	{
		SceneManager.LoadScene(newGameLevel);
	}

	public void QuitButton()
	{
		Application.Quit();
	}
}
