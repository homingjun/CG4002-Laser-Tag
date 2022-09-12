using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldHP : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textShieldHP;
    public int shieldHP = 0;

    // Start is called before the first frame update
    void Start()
    {
        textShieldHP.text = shieldHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHP <= 0)
        {
            shieldHP = 0;
        }
        textShieldHP.text = shieldHP.ToString();
    }
}
