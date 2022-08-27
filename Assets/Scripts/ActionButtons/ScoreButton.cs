using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Score P1").GetComponent<Button>();
        scoreManager = GameObject.Find("Text P1 Score").GetComponent<ScoreManager>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        scoreManager.currentScore += 1;
        scoreManager.lastScore = scoreManager.currentScore;
    }
}
