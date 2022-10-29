using UnityEngine;

public class P1GrenadeAction : MonoBehaviour
{
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private ShieldManager playerFoundStatus; //ImageTarget
    [SerializeField]
    private AudioManager grenadeSound;
    [SerializeField]
    private MQTTReceiver mqttReceiver;
    public bool isClicked = false;

    public void UseGrenade()
    {
        grenade.hasThrown = true;
        isClicked = true;
        mqttReceiver.topicPublish = "grenade17";
        if (playerFoundStatus.playerFound)
        {
            //Send grenade hit msg to ultra96
            mqttReceiver.messagePublish = "yes1";
            mqttReceiver.Publish();
        }
        else {
            //Send grenade hit msg to ultra96
            mqttReceiver.messagePublish = "no";
            mqttReceiver.Publish();
        }
        grenadeSound.GrenadeDelay();
    }
}
