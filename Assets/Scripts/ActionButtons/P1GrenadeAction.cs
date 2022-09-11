using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1GrenadeAction : MonoBehaviour
{
    private GrenadeNumber grenadeNumber;
    private Grenade grenade;
    public GameObject grenadePrefab;
    public bool isClicked = false;
    private ShieldManager playerFoundStatus;
    private OpponentHP opponentHP;


    // Start is called before the first frame update
    void Start()
    {
        Button btnOne = GameObject.Find("Button Grenade P1").GetComponent<Button>();
        grenadeNumber = GameObject.Find("Text Grenade").GetComponent<GrenadeNumber>();
        playerFoundStatus = GameObject.Find("ImageTarget").GetComponent<ShieldManager>();
        opponentHP = GameObject.Find("Text HP Opponent").GetComponent<OpponentHP>();
        grenade = grenadePrefab.GetComponent<Grenade>();
        btnOne.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (grenadeNumber.numGrenades > 0)
        {
            grenadeNumber.numGrenades -= 1;
            grenade.hasThrown = true;
            isClicked = true;
            if (playerFoundStatus.playerFound)
            {
                opponentHP.oppHP -= 30;
            }
        }
    }
}
