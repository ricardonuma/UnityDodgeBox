using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Used to switch scenes
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = true;

    public GameObject pauseMenuUI;
    public string menuScene;

    // Update is called once per frame
    void Update()
    {
        CheckPauseStatus();
    }

    void CheckPauseStatus()
    {
        // check if pause button(escape key) is pressed
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("return"))
        {
            isPaused = !isPaused;
            //check if game is already paused       
            if (isPaused == true)
            {
                //unpause the game
                Resume();
            }

            //else if game isn't paused, then pause it
            else if (isPaused == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void MenuClick()
    {
        Resume();
        SceneManager.LoadScene(menuScene);
    }

    public void QuitClick()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
        Application.Quit();
#elif (UNITY_WEBGL)
        Application.OpenURL("https://koki20.itch.io/dodgebox");
#endif
    }
}
