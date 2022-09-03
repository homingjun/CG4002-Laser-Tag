using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldButton : MonoBehaviour
{
    private ShieldManager shieldManagerHP;
    private ShieldManager shieldManagerTimer;
    private TextMeshProUGUI shieldManagerTimerStatus;
    private MeshRenderer meshStatus;
    private CircleCollider2D colliderStatus;
    private bool timerStatus = false;
    private float timeLeft = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Shield").GetComponent<Button>();
        shieldManagerHP = GameObject.Find("Text Shield").GetComponent<ShieldManager>();
        shieldManagerTimer = GameObject.Find("Text Shield Timer").GetComponent<ShieldManager>();
        shieldManagerTimerStatus = GameObject.Find("Text Shield Timer").GetComponent<TextMeshProUGUI>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        timerStatus = true;
        shieldManagerTimerStatus.enabled = true;
        shieldManagerHP.shieldHP = 30;
        meshStatus = GameObject.Find("First Person Shield").GetComponent<MeshRenderer>();
        colliderStatus = GameObject.Find("First Person Shield").GetComponent<CircleCollider2D>();
        meshStatus.enabled = true;
        colliderStatus.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStatus)
        {
            timeLeft -= Time.deltaTime;
            updateTimer(timeLeft);
        }

        if (timeLeft <= 0f)
        {
            timerStatus = false;
            RemoveShield();
        }
    }

    /*
        Disable the shield components, set the shield hp back to 0 and disable the timer text.
    */
    void RemoveShield()
    {
        meshStatus.enabled = false;
        colliderStatus.enabled = false;
        shieldManagerHP.shieldHP = 0;
        shieldManagerTimerStatus.enabled = false;
    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        shieldManagerTimer.shieldTimer = (int)seconds;
        shieldManagerTimer.textShield.text = shieldManagerTimer.shieldTimer.ToString();
    }
}
