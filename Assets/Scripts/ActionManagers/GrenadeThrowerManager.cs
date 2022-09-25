using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrowerManager : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private float throwForce = 40f;
    [SerializeField]
    private float throwHeight = 0.5f;
    [SerializeField]
    private float throwHeightOpp = 0.5f;
    public GameObject grenadePrefab;
    private P1GrenadeAction grenadeButtonPlayerOne;
    private P2GrenadeAction grenadeButtonPlayerTwo;


    // Start is called before the first frame update
    void Update()
    {
        grenadeButtonPlayerOne = GameObject.Find("Grenade P1").GetComponent<P1GrenadeAction>();
        //Debug.Log(clicked.isClicked);
        if (grenadeButtonPlayerOne.isClicked)
        {
            ThrowGrenadeViewOne();
        }

        grenadeButtonPlayerTwo = GameObject.Find("Grenade P2").GetComponent<P2GrenadeAction>();
        //Debug.Log(clicked.isClicked);
        if (grenadeButtonPlayerTwo.isClicked)
        {
            ThrowGrenadeViewTwo();
        }
    }

    // Update is called once per frame
    void ThrowGrenadeViewOne()
    {
        Vector3 temp = cam.position;
        temp.y = throwHeight;
        GameObject grenade = Instantiate(grenadePrefab, temp, cam.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(cam.forward * throwForce, ForceMode.Impulse);
        grenadeButtonPlayerOne.isClicked = false;
    }

    void ThrowGrenadeViewTwo()
    {
        Vector3 temp = cam.position;
        temp.y = throwHeightOpp;
        temp.z = 10f;
        GameObject grenade = Instantiate(grenadePrefab, temp, cam.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(cam.forward * -throwForce, ForceMode.Impulse);
        grenadeButtonPlayerTwo.isClicked = false;
    }
}
