using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class P2ShootAction : MonoBehaviour
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

        if (Convert.ToInt32(json["p2"]["shield_health"]) <= 0 && json["p1"]["bullet_hit"].ToString() == "yes")
        {
            Instantiate(bulletHitEffect, temp, cam.rotation);
        }
        bulletSound.PlayBulletSound();
    }
}
