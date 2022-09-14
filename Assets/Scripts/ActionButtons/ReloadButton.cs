using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    [SerializeField]
    private AmmoUIManager ammoPlayerOne; //Text Ammo
    [SerializeField]
    private AmmoUIManager ammoPlayerTwo; //Text Ammo Opponent
    [SerializeField]
    private AudioManager reloadSound;


    // Start is called before the first frame update
    void Start()
    {
        Button btnOne = GameObject.Find("Button Reload P1").GetComponent<Button>();
        btnOne.onClick.AddListener(ReloadPlayerOne);
        Button btnTwo = GameObject.Find("Button Reload P2").GetComponent<Button>();
        btnTwo.onClick.AddListener(ReloadPlayerTwo);
    }

    void ReloadPlayerOne()
    {
        if (ammoPlayerOne.numAmmo < 6)
        {
            ammoPlayerOne.numAmmo = 6;
            reloadSound.PlayReloadSound();
        }
    }

    void ReloadPlayerTwo()
    {
        if (ammoPlayerTwo.numAmmo < 6)
        {
            ammoPlayerTwo.numAmmo = 6;
            reloadSound.PlayReloadSound();
        }
    }
}
