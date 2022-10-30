using System;
using UnityEngine;
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
    private P1UIManager textWarning; 
    [SerializeField]
    private AudioManager sound; //Canvas
    private string previousTextWarning = "";
    private string action1 = "";
    private string action2 = "";
    private string imuStatus1 = "";
    private string gunStatus1 = "";
    private string vestStatus1 = "";
    private string imuStatus2 = "";
    private string gunStatus2 = "";
    private string vestStatus2 = "";

    void Start()
    {
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        currentJson = JObject.Parse(newMsg);

        if (currentJson.ToString().Contains("action") && !previousTextWarning.Contains("dc")) {
            action1 = currentJson["p1"]["action"].ToString();
            action2 = currentJson["p2"]["action"].ToString();

            //Set previousJson to the currentJson (for the first iteration,) when it is null.
            if (previousJson == null)
                {
                    previousJson = currentJson;
                }

            p1UI.UpdateUI(currentJson);
            p2UI.UpdateUI(currentJson);

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
                    textWarning.textWarning.text = "Please Reload!";
                    previousTextWarning = textWarning.textWarning.text;
                    sound.PlayPleaseReloadSound();
                    Invoke("RemoveWarning", 3f);
                    break;
                case "fail_grenade":
                    textWarning.textWarning.text = "Out of Grenades!";
                    previousTextWarning = textWarning.textWarning.text;
                    sound.PlayOutOfGrenadesSound();
                    Invoke("RemoveWarning", 3f);
                    break;
                case "fail_shield":
                    if (Convert.ToInt32(currentJson["p1"]["num_shield"]) == 0) {
                        textWarning.textWarning.text = "Out of Shields!";
                        previousTextWarning = textWarning.textWarning.text;
                        sound.PlayOutOfShieldsSound();
                        Invoke("RemoveWarning", 3f);
                    }
                    else {
                        textWarning.textWarning.text = "Shield Already Active!";
                        previousTextWarning = textWarning.textWarning.text; 
                        sound.PlayShieldAlreadyActiveSound();
                        Invoke("RemoveWarning", 3f);      
                    }  
                    break;
                case "fail_reload":
                    if (Convert.ToInt32(currentJson["p1"]["bullets"]) == 6) {
                        textWarning.textWarning.text = "Already Reloaded!";
                        previousTextWarning = textWarning.textWarning.text;
                        sound.PlayAlreadyReloadedSound();
                        Invoke("RemoveWarning", 3f);
                    }
                    else {
                        textWarning.textWarning.text = "You have Bullets!";
                        previousTextWarning = textWarning.textWarning.text;
                        sound.PlayYouHaveBulletsSound();
                        Invoke("RemoveWarning", 3f);
                    }
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
        }      
     
        if (currentJson.ToString().Contains("imu")) {
            if (currentJson.ToString().Contains("p1")) {
                imuStatus1 = currentJson["p1"]["imu"].ToString();
                gunStatus1 = currentJson["p1"]["gun"].ToString();
                vestStatus1 = currentJson["p1"]["vest"].ToString();
            }
            if (currentJson.ToString().Contains("p2")) {
                imuStatus2 = currentJson["p2"]["imu"].ToString();
                gunStatus2 = currentJson["p2"]["gun"].ToString();
                vestStatus2 = currentJson["p2"]["vest"].ToString();
            }
            
            //check disconnection status
            if (imuStatus1 == "no" && gunStatus1 == "no" && vestStatus1 == "no") {
                textWarning.textWarning.text = "IMU, Gun and Vest Disconnected!";
                previousTextWarning = "dc";
                sound.PlayIGVDisconnectedSound();
            }
            else if (imuStatus1 == "no" && gunStatus1 == "no") {
                textWarning.textWarning.text = "IMU and Gun Disconnected!";
                previousTextWarning = "dc";
                sound.PlayIGDisconnectedSound();
            }
            else if (imuStatus1 == "no" && vestStatus1 == "no") {
                textWarning.textWarning.text = "IMU and Vest Disconnected!";
                previousTextWarning = "dc";
                sound.PlayIVDisconnectedSound();
            }
            else if (gunStatus1 == "no" && vestStatus1 == "no") {
                textWarning.textWarning.text = "Gun and Vest Disconnected!";
                previousTextWarning = textWarning.textWarning.text;
                sound.PlayGVDisconnectedSound();
            }
            else if (imuStatus1 == "no") {
                textWarning.textWarning.text = "IMU Disconnected!";
                previousTextWarning = "dc";
                sound.PlayImuDisconnectedSound();
            }
            else if (gunStatus1 == "no") {
                textWarning.textWarning.text = "Gun Disconnected!";
                previousTextWarning = "dc";
                sound.PlayGunDisconnectedSound();
            }
            else if (vestStatus1 == "no") {
                textWarning.textWarning.text = "Vest Disconnected!";
                previousTextWarning = "dc";
                sound.PlayVestDisconnectedSound();
            }
            else if (imuStatus2 != "no" && gunStatus2 != "no" && vestStatus2 != "no") {
                textWarning.textWarning.text = "";
                previousTextWarning = "";
            }                

            if (imuStatus2 == "no" || gunStatus2 == "no" || vestStatus2 == "no") {
                textWarning.textWarningOpp.text = "Opponent has a disconnection!";
                previousTextWarning = "dc";
                sound.PlayOpponentDisconnectedSound();
            }
            else if (imuStatus1 != "no" && gunStatus1 != "no" && vestStatus1 != "no"){
                textWarning.textWarningOpp.text = "";
                previousTextWarning = "";
            }
        }
        else if (!currentJson.ToString().Contains("action")) {
            textWarning.textWarning.text = "";
            previousTextWarning = "";
            textWarning.textWarningOpp.text = "";
        }
        
        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }

    void RemoveWarning() {
        textWarning.textWarning.text = "";
        previousTextWarning = "";
    }
}