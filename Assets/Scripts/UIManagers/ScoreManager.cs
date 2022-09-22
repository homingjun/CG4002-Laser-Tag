using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textPlayerOneScore;
    [SerializeField]
    private TMP_Text textPlayerTwoScore;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    /*[SerializeField]
    private HPUIManager playerOneHP;
    [SerializeField]
    private HPUIManager playerTwoHP;
    [SerializeField]
    private Image hpBar;*/

    // Start is called before the first frame update
    void Start()
    {
        textPlayerOneScore.text = playerOneScore.ToString();
        textPlayerTwoScore.text = playerTwoScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerOneHP.HP <= 0)
        {
            playerTwoScore += 1;
            playerOneHP.HP = 100;
            hpBar.fillAmount = 1f;
        }

        if (playerTwoHP.HP <= 0)
        {
            playerOneScore += 1;
            playerTwoHP.HP = 100;
        }*/
        textPlayerOneScore.text = playerOneScore.ToString();
        textPlayerTwoScore.text = playerTwoScore.ToString();
    }

}
