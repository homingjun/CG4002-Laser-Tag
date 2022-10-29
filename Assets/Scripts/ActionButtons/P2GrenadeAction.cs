using UnityEngine;
public class P2GrenadeAction : MonoBehaviour
{
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private AudioManager grenadeSound;
    public bool isClicked = false;

    public void UseGrenade()
    {
        grenade.hasThrown = true;
        isClicked = true;
        grenadeSound.GrenadeDelay();
    }
}
