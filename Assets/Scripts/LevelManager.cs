using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to switch scenes
using UnityEngine.SceneManagement;

// Used for OnPointerEnter
using UnityEngine.EventSystems;

// Needed to manipulate the UI
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, IPointerEnterHandler
{
    public enum Level
    {
        Easy, Medium, Hard
    }

    public static Level selectedLevel;
    public string gameScene;

    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject quitButton;

    public void LevelEasyClick()
    {
        SelectLevel(Level.Easy);
    }

    public void LevelMediumClick()
    {
        SelectLevel(Level.Medium);
    }

    public void LevelHardClick()
    {
        SelectLevel(Level.Hard);
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

    void SelectLevel(Level level)
    {
        selectedLevel = level;

        // Load Game scene
        SceneManager.LoadScene(gameScene);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (eventData.pointerEnter.transform.parent.gameObject.name)
        {
            case "EasyButtonUI":
                EventSystem.current.SetSelectedGameObject(easyButton);
                break;
            case "MediumButtonUI":
                EventSystem.current.SetSelectedGameObject(mediumButton);
                break;
            case "HardButtonUI":
                EventSystem.current.SetSelectedGameObject(hardButton);
                break;
            case "QuitButtonUI":
                EventSystem.current.SetSelectedGameObject(quitButton);
                break;
        }
    }
}
