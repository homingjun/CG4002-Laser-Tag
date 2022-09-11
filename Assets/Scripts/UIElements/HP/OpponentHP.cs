using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpponentHP : MonoBehaviour
{
    public TMP_Text textOppHP;
    public int oppHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        textOppHP.text = oppHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (oppHP <= 0)
        {
            oppHP = 0;
        }
        textOppHP.text = oppHP.ToString();
    }
}
