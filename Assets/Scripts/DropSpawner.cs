using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed to manipulate the UI
using UnityEngine.UI;

public class DropSpawner : MonoBehaviour
{
    // Get from PlayerScore script
    public static string timerFormatted = "00:00";

    public GameObject dropObject;

    private float timer = 0;
    private float spawTimer = 0;
    private float spawInterval = 0.28F;

    private const int DEFAULT_POSITION_Y = 10;
    private const int DEFAULT_POSITION_Z = 0;

    void Start()
    {
        switch (LevelManager.selectedLevel) {
            case LevelManager.Level.Easy:
                spawInterval = 0.28F;
                break;
            case LevelManager.Level.Medium:
                spawInterval = 0.14F;
                break;
            case LevelManager.Level.Hard:
                spawInterval = 0.07F;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        // Increment timer by the seconds from the last frame to the current one
        timer += deltaTime;
        updateTimerUI();

        // Increment spawTimer by the seconds from the last frame to the current one
        spawTimer += deltaTime;

        // Check if spawTimer is equal or higher than spawnInterval
        if (spawTimer >= spawInterval)
        {
            spawnDrop();

            // Reset spawTimer
            spawTimer = 0;
        }
    }

    // Updates the TimerUI using format MM:ss
    void updateTimerUI()
    {
        // Get minutes from timer and format it to MM
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        // Get seconds from timer and format it to ss
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        // Set timerFormatted
        timerFormatted = minutes + ":" + seconds;

        // Get TimerUI component
        var timerUI = GameObject.Find("TimerUI").GetComponent<Text>();

        // Set TimerUI
        timerUI.text = timerFormatted;
    }

    void spawnDrop()
    {
        // Set random positionX from -13 to 10
        int positionX = Random.Range(-13, 10);

        // Create Vector3 with random positionX, DEFAULT_POSITION_Y and DEFAULT_POSITION_Z
        Vector3 randomPosition = new Vector3(positionX, DEFAULT_POSITION_Y, DEFAULT_POSITION_Z);

        // Spaw Drop object using randomPosition and no rotation (Quaternion.identity)
        Instantiate(dropObject, randomPosition, Quaternion.identity);
    }
}
