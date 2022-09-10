using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2GrenadeButton : MonoBehaviour
{
    private GrenadeManager grenadeManager;
    private Grenade grenade;
    public GameObject grenadePrefab;
    public bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btnTwo = GameObject.Find("Button Grenade P2").GetComponent<Button>();
        grenadeManager = GameObject.Find("Text Grenade").GetComponent<GrenadeManager>();
        grenade = grenadePrefab.GetComponent<Grenade>();
        btnTwo.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        isClicked = true;
    }
}
