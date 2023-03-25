using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Transform pickupPoint;
    private Transform player;

    public float pickupDistance;
    public float forceMultiplier;


    public bool readyToThrow;
    public bool isItemIsPicked = false;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        pickupPoint = GameObject.Find("PickupPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && isItemIsPicked && readyToThrow)
        {
            forceMultiplier = 100f;
        }
        pickupDistance = Vector3.Distance(player.position, transform.position);

        if (pickupDistance <= 2)
        {
            if(Input.GetKeyDown(KeyCode.E)&& !isItemIsPicked && pickupPoint.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = pickupPoint.position;
                this.transform.parent = GameObject.Find("PickupPoint").transform;

                isItemIsPicked = true;
                forceMultiplier = 0;
            }
        }

        if(Input.GetKeyUp(KeyCode.E) && isItemIsPicked)
        {
            readyToThrow = true;


            if(forceMultiplier > 1f)
            {
                rb.AddForce(player.transform.forward * forceMultiplier);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                isItemIsPicked = false;

                forceMultiplier = 0;
                readyToThrow = false;
            }
            forceMultiplier = 0;
        }
    }
}
