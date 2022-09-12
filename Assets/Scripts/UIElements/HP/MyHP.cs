using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyHP : MonoBehaviour
{
    public TMP_Text textHP;
    public int HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        textHP.text = HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            HP = 0;
        }
        textHP.text = HP.ToString();
    }
}
