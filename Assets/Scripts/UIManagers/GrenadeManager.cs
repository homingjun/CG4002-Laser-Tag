using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeManager : MonoBehaviour
{
    public TMP_Text textGrenade;
    public int grenade = 3;
    // Start is called before the first frame update
    void Start()
    {
        textGrenade.text = grenade.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textGrenade.text = grenade.ToString();
    }
}
