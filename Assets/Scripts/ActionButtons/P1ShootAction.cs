using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class P1ShootAction : MonoBehaviour
{
    [SerializeField]
    private AudioManager bulletSound;
    [SerializeField]
    private GameObject bulletHitEffect;
    [SerializeField]
    private Transform cam;

    public void ShootBullet(JObject json)
    {
        Vector3 temp = cam.position;
        temp.z = 5;

        if (Convert.ToInt32(json["p1"]["shield_health"]) <= 0 && json["p2"]["bullet_hit"].ToString() == "yes")
        {
            Instantiate(bulletHitEffect, temp, cam.rotation);
        }
        bulletSound.PlayBulletSound();
    }
}
