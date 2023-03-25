using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Transform player;
    public bool vehicleActive;
    bool isInTransition;
    public Transform seatPoint;
    public Vector3 sittingOffset;
    public Transform exitPoint;
    [Space]
    public float transitionSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (vehicleActive && isInTransition) ExitVehicle();
        else if (!vehicleActive && isInTransition) EnterVehicle();

        if (Input.GetKeyDown(KeyCode.F))
        {
            isInTransition = true;
        }
    }

    private void EnterVehicle()
    {
        //Disabling Component
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;

        //move player to desired position
        player.position = Vector3.Lerp(player.position, seatPoint.position + sittingOffset, transitionSpeed);
        player.rotation = Quaternion.Slerp(player.rotation, seatPoint.rotation, transitionSpeed);

        player.transform.parent = transform;

        //set player animation to sitting
        /* *
         * player.GetComponentInChildren<Animator>().SetBool("Sitting", true);
         * */

        //reset check
        if(player.position == seatPoint.position + sittingOffset)
        {
            isInTransition = false;
            vehicleActive = true;
        }


    }
    private void ExitVehicle()
    {
        player.position = Vector3.Lerp(player.position, exitPoint.position, transitionSpeed);

        // animation

        //player.GetComponentInChildren<Animator>().SetBool("Sitting", false);


        if(player.position == exitPoint.position)
        {
            isInTransition = false;
            vehicleActive = false;

            player.GetComponent<CapsuleCollider>().enabled = true;
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
