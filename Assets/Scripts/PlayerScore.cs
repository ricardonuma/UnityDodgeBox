using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed to manipulate the UI
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get ScoreUI component
        var scoreUI = GameObject.Find("ScoreUI").GetComponent<Text>();

        // Set ScoreUI
        scoreUI.text = "Time:\n" + DropSpawner.timerFormatted;
    }
}
