using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;

public class MQTTController : MonoBehaviour
{
    public string nameController = "Visualizer17";

    public MQTTReceiver _eventSender;
    private JObject currentJson;
    public JObject previousJson;
    [SerializeField]
    private P1UIManager p1UI;
    [SerializeField]
    private P2UIManager p2UI;
    [SerializeField]
    private P1GrenadeAction p1Grenade;
    [SerializeField]
    private P2GrenadeAction p2Grenade;
    [SerializeField]
    private P1ShieldAction p1Shield;
    [SerializeField]
    private P2ShieldAction p2Shield;
    [SerializeField]
    private P1ShootAction p1Shoot;
    [SerializeField]
    private P2ShootAction p2Shoot;
    [SerializeField]
    private ReloadButton reload;
    [SerializeField]
    private GameOverUIManager winner;
    [SerializeField]
    private P1UIManager textInfo;
    [SerializeField]
    private P1UIManager textWarning;
    [SerializeField]
    private AudioManager dcSound; //Canvas

    void Start()
    {
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        currentJson = JObject.Parse(newMsg);
        if (previousJson == null)
        {
            previousJson = currentJson;
        }

        textInfo.textInfo.text = "";

        string action1 = currentJson["p1"]["action"].ToString();
        string action2 = currentJson["p2"]["action"].ToString();
        string connection = currentJson["connection"].ToString();

        switch (action1)
        {
            case "shoot":
                p1Shoot.ShootBullet(currentJson);
                break;
            case "grenade":
                p1Grenade.UseGrenade();
                break;
            case "shield":
                p1Shield.UseShield(currentJson);
                break;
            case "reload":
                reload.ReloadPlayerOne();
                break;
            case "fail_shoot":
                textInfo.textInfo.text = "Please Reload!";
                break;
            case "fail_grenade":
                textInfo.textInfo.text = "Out of Grenades!";
                break;
            case "fail_shield":
                textInfo.textInfo.text = "Out of Shields!";
                break;
            case "fail_reload":
                textInfo.textInfo.text = "Already Reloaded!";
                break;
            case "logout":
                winner.GameWinner(currentJson);
                break;
        }

        switch (action2)
        {
            case "shoot":
                p2Shoot.ShootBullet(currentJson);
                break;
            case "grenade":
                p2Grenade.UseGrenade();
                break;
            case "shield":
                p2Shield.UseShield(currentJson);
                break;
            case "reload":
                reload.ReloadPlayerTwo();
                break;
            case "logout":
                winner.GameWinner(currentJson);
                break;
        }

        switch (connection)
        {
            case "imu":
                textWarning.textWarning.text = "IMU Disconnected!";
                dcSound.PlayImuDisconnectedSound();
                break;
            case "gun":
                textWarning.textWarning.text = "Gun Disconnected!";
                dcSound.PlayGunDisconnectedSound();
                break;
            case "vest":
                textWarning.textWarning.text = "Vest Disconnected!";
                dcSound.PlayVestDisconnectedSound();
                break;
            default:
                textWarning.textWarning.text = "";
                break;
        }

        p1UI.UpdateUI(currentJson);
        p2UI.UpdateUI(currentJson);

        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }

}