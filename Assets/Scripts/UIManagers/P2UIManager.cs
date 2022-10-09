using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class P2UIManager : MonoBehaviour
{
    [SerializeField]
    private HPUIManager hpCount; //Text HP Opponent
    [SerializeField]
    private AmmoUIManager ammoCount; //Text Ammo Opponent
    [SerializeField]
    private GrenadeUIManager grenadeCount; //Text Grenade Opponent
    [SerializeField]
    private ShieldUIManager shieldHPCount; //Text Shield Opponent
    [SerializeField]
    private ShieldUIManager shieldCount; //Text Shield Number Opponent
    [SerializeField]
    private ShieldUIManager shieldTimer; //Text Shield Timer Opponent
    [SerializeField]
    private ScoreManager p2Score; //Text P2 Score
    [SerializeField]
    private Image shieldCooldown; //Shield Fill Opponent

    // Start is called before the first frame update
    void Start()
    {

    }


    public void UpdateUI(JObject json)
    {
        hpCount.HP = Convert.ToInt32(json["p2"]["hp"]);

        ammoCount.numAmmo = Convert.ToInt32(json["p2"]["bullets"]);

        grenadeCount.numGrenades = Convert.ToInt32(json["p2"]["grenades"]);

        shieldHPCount.shieldHP = Convert.ToInt32(json["p2"]["shield_health"]);
        shieldCount.numShield = Convert.ToInt32(json["p2"]["num_shield"]);
        shieldTimer.shieldTimer = Convert.ToInt32(json["p2"]["shield_time"]);
        shieldCooldown.fillAmount = Convert.ToUInt32(json["p2"]["shield_time"]) / 10f;

        p2Score.playerTwoScore = Convert.ToInt32(json["p2"]["num_deaths"]);
    }
}
