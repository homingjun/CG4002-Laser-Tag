using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    private GrenadeButton clicked;


    // Start is called before the first frame update
    void Update()
    {
        clicked = GameObject.Find("Button Grenade").GetComponent<GrenadeButton>();
        //Debug.Log(clicked.isClicked);
        if (clicked.isClicked)
        {
            ThrowGrenade();
        }
    }

    // Update is called once per frame
    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        clicked.isClicked = false;
    }
}
