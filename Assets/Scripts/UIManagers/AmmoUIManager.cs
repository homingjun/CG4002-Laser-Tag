using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUIManager : MonoBehaviour
{
    public TMP_Text textAmmo;
    public int numAmmo = 6;
    // Start is called before the first frame update
    void Start()
    {
        textAmmo.text = numAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textAmmo.text = numAmmo.ToString();
    }
}
