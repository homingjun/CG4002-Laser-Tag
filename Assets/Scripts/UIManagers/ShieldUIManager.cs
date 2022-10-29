using UnityEngine;
using TMPro;

public class ShieldUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textShieldHP;
    public int shieldHP = 0;
    [SerializeField]
    private TMP_Text textShieldNumber;
    public int numShield = 3;
    [SerializeField]
    private TMP_Text textShieldTimer;
    public int shieldTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        textShieldHP.text = shieldHP.ToString();
        textShieldNumber.text = numShield.ToString();
        textShieldTimer.text = shieldTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHP <= 0)
        {
            shieldHP = 0;
        }
        textShieldHP.text = shieldHP.ToString();
        textShieldNumber.text = numShield.ToString();
        textShieldTimer.text = shieldTimer.ToString();
    }
}
