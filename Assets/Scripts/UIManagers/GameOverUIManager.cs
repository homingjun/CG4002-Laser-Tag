using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textWinner;
    [SerializeField]
    private TMP_Text textGameover;
    [SerializeField]
    private TMP_Text textQuit;
    [SerializeField]
    private Image background;
    [SerializeField]
    private Button buttonQuit;

    void Start()
    {
        textWinner.GetComponent<TextMeshProUGUI>().enabled = false;
        textGameover.GetComponent<TextMeshProUGUI>().enabled = false;
        textQuit.GetComponent<TextMeshProUGUI>().enabled = false;
        background.GetComponent<Image>().enabled = false;
        buttonQuit.GetComponent<Button>().enabled = false;
        buttonQuit.GetComponent<Image>().enabled = false;
    }

    public void GameWinner(JObject json)
    {
        textWinner.GetComponent<TextMeshProUGUI>().enabled = true;
        textGameover.GetComponent<TextMeshProUGUI>().enabled = true;
        textQuit.GetComponent<TextMeshProUGUI>().enabled = true;
        background.GetComponent<Image>().enabled = true;
        buttonQuit.GetComponent<Button>().enabled = true;
        buttonQuit.GetComponent<Image>().enabled = true;
        if (Convert.ToInt32(json["p1"]["num_kills"]) == Convert.ToInt32(json["p2"]["num_kills"]))
        {
            textWinner.text = "Game Draw!";
        }
        else if (Convert.ToInt32(json["p1"]["num_kills"]) > Convert.ToInt32(json["p2"]["num_kills"]))
        {
            textWinner.text = "Player 1 Wins!";
        }
        else
        {
            textWinner.text = "Player 2 Wins!";
        }
    }
}
