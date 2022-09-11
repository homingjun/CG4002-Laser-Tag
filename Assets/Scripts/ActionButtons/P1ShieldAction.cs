using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P1ShieldAction : MonoBehaviour
{
    [SerializeField]
    private ShieldHP shieldHP; //Text Shield
    [SerializeField]
    private ShieldTimer shieldTimer; //Text Shield Timer
    [SerializeField]
    private ShieldNumber shieldNumber; //Text Shield Number
    [SerializeField]
    private TextMeshProUGUI shieldManagerTimerStatus; //Text Shield Timer
    [SerializeField]
    private ShieldManager shieldManagerPlayerOneShieldStatus; //ImageTarget
    [SerializeField]
    private Image shieldCooldown; //Shield Icon
    [SerializeField]
    private Image shieldBar; //Shield Bar
    private bool timerStatus = false;
    private float cooldownTime = 10f;
    private float cooldownTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Shield P1").GetComponent<Button>();

        shieldCooldown.fillAmount = 0.0f;
        shieldBar.fillAmount = 0.0f;

        btn.onClick.AddListener(TaskOnClick);
    }

    /*
        Enable the shield timer components, set the shield hp and enable the shield bar.
    */
    void TaskOnClick()
    {
        if (shieldNumber.numShield > 0)
        {
            timerStatus = true;

            shieldHP.shieldHP = 30;
            shieldBar.fillAmount = 1f;
            shieldNumber.numShield -= 1;

            shieldManagerPlayerOneShieldStatus.playerOneShieldStatus = true;
            shieldManagerTimerStatus.enabled = true;

            cooldownTimer = cooldownTime;
        }
    }

    /*
        Set the shield hp back to 0, remove the shield bar and disable the timer components.
    */
    void RemoveShield()
    {
        shieldHP.shieldHP = 0;
        shieldBar.fillAmount = 0.0f;

        shieldManagerTimerStatus.enabled = false;
        shieldManagerPlayerOneShieldStatus.playerOneShieldStatus = false;
    }


    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        shieldTimer.shieldTimer = (int)seconds;
        //shieldTimer.textShield.text = shieldTimer.shieldTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStatus)
        {
            cooldownTimer -= Time.deltaTime;
            shieldCooldown.fillAmount = cooldownTimer / cooldownTime;
            UpdateTimer(cooldownTimer);
        }

        if (cooldownTimer <= 0f)
        {
            timerStatus = false;
            RemoveShield();
        }
    }
}
