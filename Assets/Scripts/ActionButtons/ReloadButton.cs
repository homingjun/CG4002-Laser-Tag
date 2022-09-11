using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private AmmoNumber ammoNumber;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Reload").GetComponent<Button>();
        ammoNumber = GameObject.Find("Text Ammo").GetComponent<AmmoNumber>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (ammoNumber.numAmmo < 6)
            ammoNumber.numAmmo = 6;
    }
}
