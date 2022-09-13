using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource bulletSound;
    [SerializeField]
    private AudioSource grenadeSound;
    [SerializeField]
    private AudioSource shieldSound;

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
}
