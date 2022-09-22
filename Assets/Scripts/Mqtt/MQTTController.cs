using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;

public class MQTTController : MonoBehaviour
{
    public string nameController = "Visualizer17";

    public MQTTReceiver _eventSender;
    private JObject json;
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

    void Start()
    {
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        json = JObject.Parse(newMsg);

        if (json["p1"]["action"].ToString() == "grenade")
        {
            p1Grenade.UseGrenade();
            Debug.Log("Clicked");
        }
        if (json["p2"]["action"].ToString() == "grenade")
        {
            p2Grenade.UseGrenade();
        }
        if (json["p1"]["action"].ToString() == "shield")
        {
            p1Shield.UseShield();
        }
        if (json["p2"]["action"].ToString() == "shield")
        {
            p2Shield.UseShield();
        }

        p1UI.UpdateUI(json);
        p2UI.UpdateUI(json);

        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }

}