using System;
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
    private ShieldUIManager shieldHP; //Text Shield Opponent
    [SerializeField]
    private ShieldUIManager shieldCount; //Text Shield Number Opponent
    [SerializeField]
    private ShieldUIManager shieldTimer; //Text Shield Timer Opponent
    [SerializeField]
    private ScoreManager p2Score; //Text P2 Score
    [SerializeField]
    private Image shieldCooldown; //Shield Fill Opponent
    private bool timerStatus = false;
    private float cooldownTime = 10f;
    private float cooldownTimer = 0.0f;
    [SerializeField]
    private P2ShieldAction p2Shield;

    public void UpdateUI(JObject json)
    {
        hpCount.HP = Convert.ToInt32(json["p2"]["hp"]);

        ammoCount.numAmmo = Convert.ToInt32(json["p2"]["bullets"]);

        grenadeCount.numGrenades = Convert.ToInt32(json["p2"]["grenades"]);

        
        shieldHP.shieldHP = Convert.ToInt32(json["p2"]["shield_health"]);
        shieldCount.numShield = Convert.ToInt32(json["p2"]["num_shield"]);

        if (Convert.ToInt32(json["p2"]["num_shield"]) >= 0 && json["p2"]["action"].ToString() == "shield")
        {
            timerStatus = true;
            cooldownTimer = Convert.ToUInt32(json["p2"]["shield_time"]);
            shieldTimer.shieldTimer = Convert.ToInt32(json["p2"]["shield_time"]);
            shieldCooldown.fillAmount = Convert.ToUInt32(json["p2"]["shield_time"]) / 10f;
        }

        p2Score.playerTwoScore = Convert.ToInt32(json["p1"]["num_deaths"]);
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
                p2Shield.RemoveShield();
                timerStatus = false;
            }
        }
    }
}
