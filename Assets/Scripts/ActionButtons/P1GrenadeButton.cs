using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1GrenadeButton : MonoBehaviour
{
    private GrenadeManager grenadeManager;
    private Grenade grenade;
    public GameObject grenadePrefab;
    public bool isClicked = false;
    private ShieldManager playerFoundStatus;
    private HPManager opponentHP;


    // Start is called before the first frame update
    void Start()
    {
        Button btnOne = GameObject.Find("Button Grenade P1").GetComponent<Button>();
        grenadeManager = GameObject.Find("Text Grenade").GetComponent<GrenadeManager>();
        playerFoundStatus = GameObject.Find("ImageTarget").GetComponent<ShieldManager>();
        opponentHP = GameObject.Find("Text HP").GetComponent<HPManager>();
        grenade = grenadePrefab.GetComponent<Grenade>();
        btnOne.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (grenadeManager.numGrenades > 0)
        {
            grenadeManager.numGrenades -= 1;
            grenade.hasThrown = true;
            isClicked = true;
            if (playerFoundStatus.playerFound)
            {
                opponentHP.oppHP -= 30;
            }
        }
    }
}
