using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeButton : MonoBehaviour
{
    private GrenadeManager grenadeManager;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Grenade").GetComponent<Button>();
        grenadeManager = GameObject.Find("Text Grenade").GetComponent<GrenadeManager>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (grenadeManager.grenade > 0)
        {
            grenadeManager.grenade -= 1;
        }
    }
}
