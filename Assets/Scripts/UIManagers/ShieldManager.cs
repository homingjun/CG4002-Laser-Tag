using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldManager : MonoBehaviour
{
    public TMP_Text textShield;
    public int shieldHP = 0;
    public int shieldTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        textShield.text = shieldHP.ToString();
        textShield.text = shieldTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textShield.text = shieldHP.ToString();
        textShield.text = shieldTimer.ToString();
    }
}
