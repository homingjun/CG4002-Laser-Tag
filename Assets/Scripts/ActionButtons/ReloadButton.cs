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
