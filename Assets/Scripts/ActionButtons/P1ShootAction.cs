using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class P1ShootAction : MonoBehaviour
{
    [SerializeField]
    private AmmoUIManager ammoNumber; //Text Ammo
    [SerializeField]
    private ShieldManager playerFoundStatus;
    [SerializeField]
    private HPUIManager opponentHP; //Text HP Opponent
    [SerializeField]
    private ShieldUIManager opponentShieldHP; //Text Shield Opponent
    [SerializeField]
    private AudioManager bulletSound;
    [SerializeField]
    private GameObject bulletHitEffect;
    [SerializeField]
    private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = GameObject.Find("Shoot P1").GetComponent<Button>();
        //btn.onClick.AddListener(ShootBullet);
    }

    public void ShootBullet(JObject json)
    {
        Vector3 temp = cam.position;
        temp.z = 5;
        /*if (ammoNumber.numAmmo > 0)
        {
            ammoNumber.numAmmo -= 1;
            if (playerFoundStatus.playerFound && opponentShieldHP.shieldHP > 0)
            {
                opponentShieldHP.shieldHP -= 10;
                Instantiate(bulletHitEffect, temp, cam.rotation);
            }
            else if (playerFoundStatus.playerFound)
            {
                opponentHP.HP -= 10;
                Instantiate(bulletHitEffect, temp, cam.rotation);
            }
            bulletSound.PlayBulletSound();
        }*/

        if (Convert.ToInt32(json["p2"]["shield_health"]) <= 0 && json["p1"]["bullet_hit"].ToString() == "yes")
        {
            Instantiate(bulletHitEffect, temp, cam.rotation);
        }
        bulletSound.PlayBulletSound();
    }
}
