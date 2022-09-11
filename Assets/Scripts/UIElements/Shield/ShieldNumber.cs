using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldNumber : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textShieldNumber;
    public int numShield = 3;

    // Start is called before the first frame update
    void Start()
    {
        textShieldNumber.text = numShield.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textShieldNumber.text = numShield.ToString();
    }
}
