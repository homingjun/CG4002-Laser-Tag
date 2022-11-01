using UnityEngine;

public class P1ShootAction : MonoBehaviour
{
    [SerializeField]
    private AudioManager bulletSound;

    public void ShootBullet()
    {
        bulletSound.PlayBulletSound();
    }
}
