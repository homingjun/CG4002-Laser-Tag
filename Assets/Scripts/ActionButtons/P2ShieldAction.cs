using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class P2ShieldAction : MonoBehaviour
{
    [SerializeField]
    private ShieldUIManager shieldHP; //Text Shield Opponent
    [SerializeField]
    private TextMeshProUGUI shieldManagerTimerStatus; //Text Shield Timer Opponent
    [SerializeField]
    private ShieldManager shieldManagerPlayerTwoShield; //ImageTarget
    [SerializeField]
    private AudioManager shieldSound; //Canvas
    [SerializeField]
    private Image shieldCooldown; //Shield Fill Opponent
    [SerializeField]
    private MeshRenderer shieldMesh; //Shield

    // Start is called before the first frame update
    void Start()
    {
        shieldCooldown.fillAmount = 0.0f;
    }

    /*
        Enable the shield timer components, set the shield hp and enable the shield bar.
    */
    public void UseShield(JObject json)
    {
        if (Convert.ToInt32(json["p2"]["num_shield"]) >= 0)
        {
            shieldSound.PlayShieldSound();
            shieldManagerPlayerTwoShield.playerTwoShieldStatus = true;
            shieldManagerTimerStatus.enabled = true;
            if (shieldManagerPlayerTwoShield.playerFound) {
                shieldMesh.enabled = true;
            }
        }
    }

    /*
        Set the shield hp back to 0, remove the shield bar and disable the timer components.
    */
    public void RemoveShield()
    {
        shieldSound.PlayShieldBreakSound();

        shieldHP.shieldHP = 0;
        shieldCooldown.fillAmount = 0.0f;

        shieldManagerTimerStatus.enabled = false;
        shieldManagerPlayerTwoShield.playerTwoShieldStatus = false;
        shieldMesh.enabled = false;
    }
}
