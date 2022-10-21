using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class P2GrenadeAction : MonoBehaviour
{
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private AudioManager grenadeSound;
    public bool isClicked = false;

    public void UseGrenade()
    {
        grenade.hasThrown = true;
        isClicked = true;
        grenadeSound.GrenadeDelay();
    }
}
