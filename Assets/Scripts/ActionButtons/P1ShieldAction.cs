using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class P1ShieldAction : MonoBehaviour
{
    [SerializeField]
    private ShieldUIManager shieldHP; //Text Shield
    [SerializeField]
    private ShieldUIManager shieldTimer; //Text Shield Timer
    [SerializeField]
    private ShieldUIManager shieldNumber; //Text Shield Number
    [SerializeField]
    private TextMeshProUGUI shieldManagerTimerStatus; //Text Shield Timer
    [SerializeField]
    private ShieldManager shieldManagerPlayerOneShieldStatus; //ImageTarget
    [SerializeField]
    private AudioManager shieldSound; //Canvas
    [SerializeField]
    private Image shieldCooldown; //Shield Fill
    [SerializeField]
    private Image shieldBar; //Shield Bar
    [SerializeField]
    private MeshRenderer shieldMesh; //Shield

    // Start is called before the first frame update
    void Start()
    {
        shieldCooldown.fillAmount = 0.0f;
        shieldBar.fillAmount = 0.0f;
    }

    /*
        Enable the shield timer components, set the shield hp and enable the shield bar.
    */
    public void UseShield(JObject json)
    {
        if (Convert.ToInt32(json["p2"]["num_shield"]) >= 0)
        {
            shieldSound.PlayShieldSound();
            shieldManagerPlayerOneShieldStatus.playerOneShieldStatus = true;
            shieldManagerTimerStatus.enabled = true;
            shieldMesh.enabled = true;
        }
    }

    /*
        Set the shield hp back to 0, remove the shield bar and disable the timer components.
    */
    public void RemoveShield()
    {
        shieldSound.PlayShieldBreakSound();

        shieldHP.shieldHP = 0;
        shieldBar.fillAmount = 0.0f;
        shieldCooldown.fillAmount = 0.0f;

        shieldManagerTimerStatus.enabled = false;
        shieldManagerPlayerOneShieldStatus.playerOneShieldStatus = false;
        shieldMesh.enabled = false;
    }
}
