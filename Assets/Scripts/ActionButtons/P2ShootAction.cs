using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class P2ShootAction : MonoBehaviour
{
    [SerializeField]
    private AmmoUIManager ammoNumber; //Text Ammo Opponent
    [SerializeField]
    private HPUIManager opponentHP; //Text HP
    [SerializeField]
    private ShieldUIManager opponentShieldHP; //Text Shield
    [SerializeField]
    private AudioManager bulletSound;
    [SerializeField]
    private GameObject bulletHitEffect;
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private Image hpBar; // HP Bar

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = GameObject.Find("Shoot P2").GetComponent<Button>();
        //btn.onClick.AddListener(ShootBullet);
    }

    public void ShootBullet(JObject json)
    {
        Vector3 temp = cam.position;
        /*if (ammoNumber.numAmmo > 0)
        {
            ammoNumber.numAmmo -= 1;
            if (opponentShieldHP.shieldHP > 0)
                opponentShieldHP.shieldHP -= 10;
            else
            {
                opponentHP.HP -= 10;
                hpBar.fillAmount = opponentHP.HP / (float)100;
            }
            bulletSound.PlayBulletSound();
            Instantiate(bulletHitEffect, temp, cam.rotation);
        }*/

        if (Convert.ToInt32(json["p1"]["shield_health"]) <= 0 && json["p2"]["bullet_hit"].ToString() == "yes")
        {
            Instantiate(bulletHitEffect, temp, cam.rotation);
        }
        bulletSound.PlayBulletSound();
    }
}
