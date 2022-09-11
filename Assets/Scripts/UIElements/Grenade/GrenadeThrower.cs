using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public Transform cam;
    //public Transform imageTarget;
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    private P1GrenadeAction grenadeButtonPlayerOne;
    private P2GrenadeButton grenadeButtonPlayerTwo;


    // Start is called before the first frame update
    void Update()
    {
        grenadeButtonPlayerOne = GameObject.Find("Button Grenade P1").GetComponent<P1GrenadeAction>();
        //Debug.Log(clicked.isClicked);
        if (grenadeButtonPlayerOne.isClicked)
        {
            ThrowGrenadeViewOne();
        }

        grenadeButtonPlayerTwo = GameObject.Find("Button Grenade P2").GetComponent<P2GrenadeButton>();
        //Debug.Log(clicked.isClicked);
        if (grenadeButtonPlayerTwo.isClicked)
        {
            ThrowGrenadeViewTwo();
        }
    }

    // Update is called once per frame
    void ThrowGrenadeViewOne()
    {
        GameObject grenade = Instantiate(grenadePrefab, cam.position, cam.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(cam.forward * throwForce, ForceMode.Impulse);
        grenadeButtonPlayerOne.isClicked = false;
    }

    void ThrowGrenadeViewTwo()
    {
        Vector3 temp = cam.position;
        temp.y = 1.2f;
        temp.z = 10f;
        GameObject grenade = Instantiate(grenadePrefab, temp, cam.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(cam.forward * throwForce, ForceMode.Impulse);
        grenadeButtonPlayerTwo.isClicked = false;
    }
}
