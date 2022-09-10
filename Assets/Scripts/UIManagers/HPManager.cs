using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPManager : MonoBehaviour
{
    public TMP_Text textHP;
    public TMP_Text textOppHP;
    public int HP = 100;
    public int oppHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        textHP.text = HP.ToString();
        textOppHP.text = oppHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = HP.ToString();
        textOppHP.text = oppHP.ToString();
    }
}
