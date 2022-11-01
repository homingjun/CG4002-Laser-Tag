using UnityEngine;
public class P2ShootAction : MonoBehaviour
{
    [SerializeField]
    private AudioManager bulletSound;

    public void ShootBullet()
    {
        bulletSound.PlayBulletSound();
    }
}
