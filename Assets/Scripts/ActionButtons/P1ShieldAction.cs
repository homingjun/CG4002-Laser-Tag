using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private bool timerStatus = false;
    private bool firstClick = true;
    private bool shieldBroke = false;
    private float cooldownTime = 10f;
    private float cooldownTimer = 0.0f;
    private float buttonCooldownTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Shield P1").GetComponent<Button>();

        shieldCooldown.fillAmount = 0.0f;
        shieldBar.fillAmount = 0.0f;
        btn.onClick.AddListener(ShieldStatusChecker);
    }

    /*
        Checks if the shield has been activated before. 
        If it has not, activate the shield.
        If it has, ensure that 10s has passed before the shield can be used again.
    */
    void ShieldStatusChecker()
    {
        if (!timerStatus && firstClick)
        {
            TaskOnClick();
        }
        if (!timerStatus && buttonCooldownTimer >= 10f)
        {
            TaskOnClick();
        }
    }

    /*
        Enable the shield timer components, set the shield hp and enable the shield bar.
    */
    void TaskOnClick()
    {
        if (shieldNumber.numShield > 0)
        {
            timerStatus = true;
            firstClick = false;
            shieldBroke = false;
            buttonCooldownTimer = 0.0f;
            shieldSound.PlayShieldSound();

            shieldHP.shieldHP = 30;
            shieldBar.fillAmount = 1f;
            shieldNumber.numShield -= 1;

            shieldManagerPlayerOneShieldStatus.playerOneShieldStatus = true;
            shieldManagerTimerStatus.enabled = true;
            shieldMesh.enabled = true;

            cooldownTimer = cooldownTime;
        }
    }

    /*
        Set the shield hp back to 0, remove the shield bar and disable the timer components.
    */
    void RemoveShield()
    {
        timerStatus = false;
        shieldBroke = true;
        shieldSound.PlayShieldBreakSound();

        shieldHP.shieldHP = 0;
        shieldBar.fillAmount = 0.0f;
        shieldCooldown.fillAmount = 0.0f;

        shieldManagerTimerStatus.enabled = false;
        shieldManagerPlayerOneShieldStatus.playerOneShieldStatus = false;
        shieldMesh.enabled = false;
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
        if (timerStatus)
        {
            cooldownTimer -= Time.deltaTime;
            shieldCooldown.fillAmount = cooldownTimer / cooldownTime;
            UpdateTimer(cooldownTimer);
            if (cooldownTimer <= 0f || shieldHP.shieldHP <= 0)
            {
                RemoveShield();
            }
        }

        if (cooldownTimer <= 0f || shieldBroke)
        {
            buttonCooldownTimer += Time.deltaTime;
        }
    }
}
