using UnityEngine;
using TMPro;

public class GrenadeUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textGrenade;
    public int numGrenades = 2;

    // Start is called before the first frame update
    void Start()
    {
        textGrenade.text = numGrenades.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textGrenade.text = numGrenades.ToString();

    }
}
