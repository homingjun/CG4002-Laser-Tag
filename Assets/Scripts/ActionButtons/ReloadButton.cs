using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadButton : MonoBehaviour
{
    [SerializeField]
    private AudioManager reloadSound;

    public void ReloadPlayerOne()
    {
        reloadSound.PlayReloadSound();
    }

    public void ReloadPlayerTwo()
    {
        reloadSound.PlayReloadSound();
    }
}
