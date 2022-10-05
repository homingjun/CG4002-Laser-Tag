using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class P2GrenadeAction : MonoBehaviour
{
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private GrenadeUIManager grenadeNumber; //Text Grenade Opponent
    [SerializeField]
    private HPUIManager opponentHP; //Text HP
    [SerializeField]
    private ShieldUIManager opponentShieldHP; //Text Shield
    [SerializeField]
    private AudioManager grenadeSound;
    [SerializeField]
    private Image hpBar; //HP Bar
    public bool isClicked = false;
    private int currentShieldHP;


    // Start is called before the first frame update
    void Start()
    {
        //Button btnOne = GameObject.Find("Grenade P2").GetComponent<Button>();
        //btnOne.onClick.AddListener(UseGrenade);
    }

    public void UseGrenade(JObject json)
    {
        /*if (grenadeNumber.numGrenades > 0)
        {
            grenadeNumber.numGrenades -= 1;
            grenade.hasThrown = true;
            isClicked = true;
            if (opponentShieldHP.shieldHP > 0)
            {
                currentShieldHP = opponentShieldHP.shieldHP;
                currentShieldHP -= 30;
                opponentShieldHP.shieldHP -= 30;
                opponentHP.HP += currentShieldHP; //Ensures that the excess grenade damage reduces the Player's HP
            }
            else
            {
                opponentHP.HP -= 30;
                hpBar.fillAmount = opponentHP.HP / (float)100;
            }
            grenadeSound.GrenadeDelay();
        }*/
        grenade.hasThrown = true;
        isClicked = true;
        grenadeSound.GrenadeDelay();
        /*if (json["p2"]["grenade_hit"].ToString() == "yes")
        {
            grenade.hasThrown = true;
            isClicked = true;
            grenadeSound.GrenadeDelay();
        }*/
    }
}
