using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2GrenadeAction : MonoBehaviour
{
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private GrenadeNumber grenadeNumber; //Text Grenade Opponent
    [SerializeField]
    private MyHP opponentHP; //Text HP
    [SerializeField]
    private ShieldHP opponentShieldHP; //Text Shield
    [SerializeField]
    private Image hpBar;
    public bool isClicked = false;
    private int currentShieldHP;


    // Start is called before the first frame update
    void Start()
    {
        Button btnOne = GameObject.Find("Button Grenade P2").GetComponent<Button>();
        btnOne.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (grenadeNumber.numGrenades > 0)
        {
            grenadeNumber.numGrenades -= 1;
            grenade.hasThrown = true;
            isClicked = true;
            if (opponentShieldHP.shieldHP > 0)
            {
                currentShieldHP = opponentShieldHP.shieldHP;
                currentShieldHP -= 30;
                opponentShieldHP.shieldHP -= 30;
                opponentHP.HP += currentShieldHP; //Ensures that the excess grenade damage reduces the Player's HP
            }
            else
            {
                opponentHP.HP -= 30;
                hpBar.fillAmount = opponentHP.HP / (float)100;
            }
        }
    }
}
