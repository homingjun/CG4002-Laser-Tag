using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1GrenadeAction : MonoBehaviour
{
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private GrenadeNumber grenadeNumber; //Text Grenade
    [SerializeField]
    private ShieldManager playerFoundStatus; //ImageTarget
    [SerializeField]
    private MyHP opponentHP; //Text HP Opponent
    [SerializeField]
    private ShieldUIManager opponentShieldHP; //Text Shield Opponent
    public bool isClicked = false;
    private int currentShieldHP;


    // Start is called before the first frame update
    void Start()
    {
        Button btnOne = GameObject.Find("Button Grenade P1").GetComponent<Button>();
        btnOne.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (grenadeNumber.numGrenades > 0)
        {
            grenadeNumber.numGrenades -= 1;
            grenade.hasThrown = true;
            isClicked = true;
            if (playerFoundStatus.playerFound && opponentShieldHP.shieldHP > 0)
            {
                currentShieldHP = opponentShieldHP.shieldHP;
                currentShieldHP -= 30;
                opponentShieldHP.shieldHP -= 30;
                opponentHP.HP += currentShieldHP; //Ensures that the excess grenade damage reduces the Player's HP
            }
            else if (playerFoundStatus.playerFound)
                opponentHP.HP -= 30;
        }
    }
}
