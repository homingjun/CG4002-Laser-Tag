using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private AmmoManager ammoManager;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Reload").GetComponent<Button>();
        ammoManager = GameObject.Find("Text Ammo").GetComponent<AmmoManager>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (ammoManager.ammo < 6)
            ammoManager.ammo = 6;
    }
}
