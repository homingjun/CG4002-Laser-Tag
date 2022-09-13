using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    [SerializeField]
    private AmmoUIManager ammoNumber; //Text Ammo
    [SerializeField]
    private ShieldManager playerFoundStatus;
    [SerializeField]
    private HPUIManager opponentHP; //Text HP Opponent
    [SerializeField]
    private ShieldUIManager opponentShieldHP; //Text Shield Opponent

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Shoot").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (ammoNumber.numAmmo > 0)
        {
            ammoNumber.numAmmo -= 1;
            if (playerFoundStatus.playerFound && opponentShieldHP.shieldHP > 0)
                opponentShieldHP.shieldHP -= 10;
            else if (playerFoundStatus.playerFound)
                opponentHP.HP -= 10;
        }

    }
}
