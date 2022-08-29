using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeButton : MonoBehaviour
{
    private GrenadeManager grenadeManager;
    private Grenade grenade;
    public GameObject grenadePrefab;
    public bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Grenade").GetComponent<Button>();
        grenadeManager = GameObject.Find("Text Grenade").GetComponent<GrenadeManager>();
        grenade = grenadePrefab.GetComponent<Grenade>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (grenadeManager.numGrenades > 0)
        {
            grenadeManager.numGrenades -= 1;
            grenade.hasThrown = true;
            isClicked = true;
        }
    }
}
