using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public TMP_Text textAmmo;
    public int ammo = 6;
    // Start is called before the first frame update
    void Start()
    {
        textAmmo.text = ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textAmmo.text = ammo.ToString();
    }
}
