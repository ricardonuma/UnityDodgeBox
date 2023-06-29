using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to switch scenes
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
	// The next scene to load
	public string sceneToLoad;

	// Time to pause before loading next scene in seconds
	private const int DEFAULT_SECONDS_TO_LOAD_SCENE = 3;

	// Use this for initialization
	void Start()
	{
        // Call function OpenNextScene after a set number of seconds
        Invoke("OpenNextScene", DEFAULT_SECONDS_TO_LOAD_SCENE);
	}

	void OpenNextScene()
	{
		// Load defined scene
		SceneManager.LoadScene(sceneToLoad);
	}
}