using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager; //Text P1 Score

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Score P1").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        scoreManager.currentScore += 1;
        scoreManager.lastScore = scoreManager.currentScore;
    }
}
