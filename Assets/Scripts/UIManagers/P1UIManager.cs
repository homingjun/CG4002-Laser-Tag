using System;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TMPro;

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
    [SerializeField]
    public TMP_Text textInfo;
    [SerializeField]
    public TMP_Text textCurrentAction;
    [SerializeField]
    public TMP_Text textPreviousAction;
    [SerializeField]
    public TMP_Text textWarning;
    [SerializeField]
    public TMP_Text textWarningOpp;
    private bool timerStatus = false;
    private float cooldownTime = 10f;
    private float cooldownTimer = 0.0f;
    [SerializeField]
    private P1ShieldAction p1Shield;
    [SerializeField]
    private MQTTController mqttController;

    // Start is called before the first frame update
    void Start()
    {
        hpBar.fillAmount = 1f;
        shieldBar.fillAmount = 0f;
        textCurrentAction.text = "Current Action: ";
        textPreviousAction.text = "Previous Action: ";
        textWarning.text = "";
        textWarningOpp.text = "";
    }

    public void UpdateUI(JObject json)
    {   
        if (json["p2"]["action"].ToString() != "none") {
            textCurrentAction.text = "Current Action: " + json["p2"]["action"].ToString();
        }
        if (mqttController.previousJson["p2"]["action"].ToString() != "none") {
            textPreviousAction.text = "Previous Action: " + mqttController.previousJson["p2"]["action"].ToString();
        }

        //Set previousJson to the current json
        mqttController.previousJson = json;

        hpCount.HP = Convert.ToInt32(json["p2"]["hp"]);
        hpBar.fillAmount = hpCount.HP / (float)100;

        ammoCount.numAmmo = Convert.ToInt32(json["p2"]["bullets"]);

        grenadeCount.numGrenades = Convert.ToInt32(json["p2"]["grenades"]);


        shieldHP.shieldHP = Convert.ToInt32(json["p2"]["shield_health"]);
        shieldCount.numShield = Convert.ToInt32(json["p2"]["num_shield"]);

        if (Convert.ToInt32(json["p2"]["num_shield"]) >= 0 && json["p2"]["action"].ToString() == "shield")
        {
            timerStatus = true;
            cooldownTimer = Convert.ToUInt32(json["p2"]["shield_time"]);
            shieldTimer.shieldTimer = Convert.ToInt32(json["p2"]["shield_time"]);
            shieldBar.fillAmount = shieldHP.shieldHP / (float)30;
            shieldCooldown.fillAmount = Convert.ToUInt32(json["p2"]["shield_time"]) / 10f;
        }

        p1Score.playerOneScore = Convert.ToInt32(json["p1"]["num_deaths"]);
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
