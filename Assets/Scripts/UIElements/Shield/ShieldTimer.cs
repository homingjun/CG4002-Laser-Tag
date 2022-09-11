using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldTimer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textShieldTimer;
    public int shieldTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        textShieldTimer.text = shieldTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textShieldTimer.text = shieldTimer.ToString();
    }
}
