using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bulletSound; //Bullet Sound
    [SerializeField]
    private AudioSource grenadeSound; //Grenade Sound
    [SerializeField]
    private AudioSource shieldSound; //Shield Sound
    [SerializeField]
    private AudioSource shieldBreakSound; //Shield Break Sound
    [SerializeField]
    private AudioSource reloadSound; //Reload Sound
    [SerializeField]
    private AudioSource pleaseReloadSound; //Please Reload Sound
    [SerializeField]
    private AudioSource outOfGrenadesSound; //Out of Grenades Sound
    [SerializeField]
    private AudioSource outOfShieldsSound; //Out of Shields Sound
    [SerializeField]
    private AudioSource shieldAlreadyActiveSound; //Shield Already Active Sound
    [SerializeField]
    private AudioSource alreadyReloadedSound; //Already Reloaded Sound
     [SerializeField]
    private AudioSource youHaveBulletsSound; //You Have Bullets Sound
    [SerializeField]
    private AudioSource imuDcSound; //IMU
    [SerializeField]
    private AudioSource gunDcSound; //GUN
    [SerializeField]
    private AudioSource vestDcSound; //VEST
    [SerializeField]
    private AudioSource igvDcSound; //IMU, GUN AND VEST
    [SerializeField]
    private AudioSource igDcSound; //IMU AND GUN
    [SerializeField]
    private AudioSource ivDcSound; //IMU AND VEST
    [SerializeField]
    private AudioSource gvDcSound; //GUN AND VEST
    [SerializeField]
    private AudioSource oppDcSound; //Opponent
    [SerializeField]
    private AudioSource drawSound; //draw sound
    [SerializeField]
    private AudioSource p1WinSound; //p1 win sound
    [SerializeField]
    private AudioSource p2WinSound; //p2 win sound

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

    public void PlayPleaseReloadSound()
    {
        pleaseReloadSound.Play();
    }

    public void PlayOutOfGrenadesSound()
    {
        outOfGrenadesSound.Play();
    }

    public void PlayOutOfShieldsSound()
    {
        outOfShieldsSound.Play();
    }

    public void PlayShieldAlreadyActiveSound()
    {
        shieldAlreadyActiveSound.Play();
    }

    public void PlayAlreadyReloadedSound()
    {
        alreadyReloadedSound.Play();
    }

    public void PlayYouHaveBulletsSound()
    {
        youHaveBulletsSound.Play();
    }

    public void PlayImuDisconnectedSound()
    {
        imuDcSound.Play();
    }

    public void PlayGunDisconnectedSound()
    {
        gunDcSound.Play();
    }

    public void PlayVestDisconnectedSound()
    {
        vestDcSound.Play();
    }

    public void PlayIGVDisconnectedSound()
    {
        igvDcSound.Play();
    }

    public void PlayIGDisconnectedSound()
    {
        igDcSound.Play();
    }

    public void PlayIVDisconnectedSound()
    {
        ivDcSound.Play();
    }

    public void PlayGVDisconnectedSound()
    {
        gvDcSound.Play();
    }

    public void PlayOpponentDisconnectedSound()
    {
        oppDcSound.Play();
    }

    public void PlayDrawSound() {
        drawSound.Play();
    }

    public void PlayPlayerOneWinSound() {
        p1WinSound.Play();
    }

    public void PlayPlayerTwoWinSound() {
        p2WinSound.Play();
    }
}
