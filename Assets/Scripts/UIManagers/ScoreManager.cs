using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public int lastScore;
    public int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if (lastScore != currentScore) // IF STATEMENT THAT CHECKS IF SCORE HAS CHANGED👈
        // {
        //     textScore.text = currentScore.ToString();
        // }
        textScore.text = currentScore.ToString();
    }

}
