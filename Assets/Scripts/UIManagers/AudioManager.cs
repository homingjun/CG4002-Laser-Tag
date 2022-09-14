using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource bulletSound; //Ammo Icon
    [SerializeField]
    private AudioSource grenadeSound; //Grenade Icon
    [SerializeField]
    private AudioSource shieldSound; //Shield Icon
    [SerializeField]
    private AudioSource shieldBreakSound; //Shield Items
    [SerializeField]
    private AudioSource reloadSound; //Ammo Items

    public void PlayBulletSound()
    {
        bulletSound.Play();
    }

    public void GrenadeDelay()
    {
        Invoke(nameof(PlayGrenadeSound), 2f);
    }
    public void PlayGrenadeSound()
    {
        grenadeSound.Play();
    }

    public void PlayShieldSound()
    {
        shieldSound.Play();
    }

    public void PlayShieldBreakSound()
    {
        shieldBreakSound.Play();
    }

    public void PlayReloadSound()
    {
        reloadSound.Play();
    }
}
