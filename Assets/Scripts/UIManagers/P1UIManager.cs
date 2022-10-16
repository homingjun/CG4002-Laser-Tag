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
    private ShieldUIManager shieldHP; //Text Shield
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

    private bool timerStatus = false;
    private float cooldownTime = 10f;
    private float cooldownTimer = 0.0f;
    [SerializeField]
    private P1ShieldAction p1Shield;

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


        shieldCount.numShield = Convert.ToInt32(json["p1"]["num_shield"]);

        if (Convert.ToInt32(json["p1"]["num_shield"]) >= 0 && json["p1"]["action"].ToString() == "shield")
        {
            timerStatus = true;
            cooldownTimer = Convert.ToUInt32(json["p1"]["shield_time"]);
            shieldHP.shieldHP = Convert.ToInt32(json["p1"]["shield_health"]);
            shieldTimer.shieldTimer = Convert.ToInt32(json["p1"]["shield_time"]);
            shieldBar.fillAmount = shieldHP.shieldHP / (float)30;
            shieldCooldown.fillAmount = Convert.ToUInt32(json["p1"]["shield_time"]) / 10f;
        }

        p1Score.playerOneScore = Convert.ToInt32(json["p2"]["num_deaths"]);
    }

    /*
        Update the shield timer shown on the Visualiser in real time.
    */
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        shieldTimer.shieldTimer = (int)seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStatus && cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            shieldCooldown.fillAmount = cooldownTimer / cooldownTime;
            UpdateTimer(cooldownTimer);
            if (cooldownTimer <= 0f || shieldHP.shieldHP <= 0)
            {
                p1Shield.RemoveShield();
                timerStatus = false;
            }
        }
    }
}
