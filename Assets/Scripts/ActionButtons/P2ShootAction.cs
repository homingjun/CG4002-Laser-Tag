using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Button btn = GameObject.Find("Button Shoot P2").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Vector3 temp = cam.position;
        if (ammoNumber.numAmmo > 0)
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
        }
    }
}
