using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class P1UIManager : MonoBehaviour
{
    [SerializeField]
    private HPUIManager hpCount; //Text HP
    [SerializeField]
    private AmmoUIManager ammoCount; //Text Ammo
    [SerializeField]
    private GrenadeUIManager grenadeCount; //Text Grenade
    [SerializeField]
    private ShieldUIManager shieldHPCount; //Text Shield
    [SerializeField]
    private ShieldUIManager shieldCount; //Text Shield Number
    [SerializeField]
    private ShieldUIManager shieldTimer; //Text Shield Timer
    [SerializeField]
    private ScoreManager p1Score; //Text P1 Score
    [SerializeField]
    private Image hpBar; //HP Bar
    [SerializeField]
    private Image shieldBar; //Shield Bar
    [SerializeField]
    private Image shieldCooldown; //Shield Fill

    // Start is called before the first frame update
    void Start()
    {
        hpBar.fillAmount = 1f;
        shieldBar.fillAmount = 0f;
    }


    public void UpdateUI(JObject json)
    {
        hpCount.HP = Convert.ToInt32(json["p1"]["hp"]);
        hpBar.fillAmount = hpCount.HP / (float)100;

        ammoCount.numAmmo = Convert.ToInt32(json["p1"]["bullets"]);

        grenadeCount.numGrenades = Convert.ToInt32(json["p1"]["grenades"]);

        shieldHPCount.shieldHP = Convert.ToInt32(json["p1"]["shield_health"]);
        shieldCount.numShield = Convert.ToInt32(json["p1"]["num_shield"]);
        shieldTimer.shieldTimer = Convert.ToInt32(json["p1"]["shield_timer"]);
        shieldBar.fillAmount = shieldHPCount.shieldHP / (float)30;
        shieldCooldown.fillAmount = Convert.ToUInt32(json["p1"]["shield_timer"]) / 10f;

        p1Score.playerOneScore = Convert.ToInt32(json["p1"]["num_kills"]);
    }
}
