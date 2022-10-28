using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

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
    private bool isJson;

    void Start()
    {
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        currentJson = JObject.Parse(newMsg);

        textInfo.textInfo.text = "";
        string action1 = "";
        string action2 = "";
        string imuStatus1;
        string gunStatus1;
        string vestStatus1;
        string imuStatus2;
        string gunStatus2;
        string vestStatus2;

        if (currentJson.ToString().Contains("action")) {
            action1 = currentJson["p1"]["action"].ToString();
            action2 = currentJson["p2"]["action"].ToString();

            //Set previousJson to the currentJson (for the first iteration,) when it is null.
            if (previousJson == null)
                {
                    previousJson = currentJson;
                }

            p1UI.UpdateUI(currentJson);
            p2UI.UpdateUI(currentJson);
        }      

        //check player 1's action
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
                if (Convert.ToInt32(currentJson["p1"]["num_shield"]) == 0)
                    textInfo.textInfo.text = "Out of Shields!";
                else
                    textInfo.textInfo.text = "Shield Already Active!";            
                break;
            case "fail_reload":
                if (Convert.ToInt32(currentJson["p1"]["bullets"]) == 6)
                    textInfo.textInfo.text = "Already Reloaded!";
                else
                    textInfo.textInfo.text = "You have Bullets!";
                break;
            case "logout":
                winner.GameWinner(currentJson);
                break;
            default:
                break;
        }

        //check player 2's action
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
            default:
                break;
        }
        
        if (currentJson.ToString().Contains("imu")) {
            imuStatus1 = currentJson["p1"]["imu"].ToString();
            gunStatus1 = currentJson["p1"]["gun"].ToString();
            vestStatus1 = currentJson["p1"]["vest"].ToString();
            imuStatus2 = currentJson["p2"]["imu"].ToString();
            gunStatus2 = currentJson["p2"]["gun"].ToString();
            vestStatus2 = currentJson["p2"]["vest"].ToString();

            //check disconnection status
            if (imuStatus1 == "no" && gunStatus1 == "no" && vestStatus1 == "no") {
                textWarning.textWarning.text = "IMU, Gun and Vest Disconnected!";
            }
            else if (imuStatus1 == "no" && gunStatus1 == "no") {
                textWarning.textWarning.text = "IMU and Gun Disconnected!";
            }
            else if (imuStatus1 == "no" && vestStatus1 == "no") {
                textWarning.textWarning.text = "IMU and Vest Disconnected!";
            }
            else if (gunStatus1 == "no" && vestStatus1 == "no") {
                textWarning.textWarning.text = "Gun and Vest Disconnected!";
            }
            else if (imuStatus1 == "no") {
                textWarning.textWarning.text = "IMU Disconnected!";
                dcSound.PlayImuDisconnectedSound();
            }
            else if (gunStatus1 == "no") {
                textWarning.textWarning.text = "Gun Disconnected!";
                dcSound.PlayGunDisconnectedSound();
            }
            else if (vestStatus1 == "no") {
                textWarning.textWarning.text = "Vest Disconnected!";
                dcSound.PlayImuDisconnectedSound();
            }
            else
                textWarning.textWarning.text = "";

            if (imuStatus2 == "no" || gunStatus2 == "no" || vestStatus2 == "no") {
                textWarning.textWarningOpp.text = "Opponent has a disconnection!";
            }
            else
                textWarning.textWarningOpp.text = "";
        }
        else {
            Debug.Log("nothing");
            textWarning.textWarning.text = "";
            textWarning.textWarningOpp.text = "";
        }
        

        

        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }

}