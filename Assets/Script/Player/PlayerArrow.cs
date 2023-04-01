using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{

    public Transform dropTarget;
    public float rotationSpeed;

    private PlayerPickup playerPickup;

    private void Start()
    {
        playerPickup = FindObjectOfType<PlayerPickup>();
    }

    private void FixedUpdate()
    {
        if (playerPickup.isHolding)
        {
            RotateArrow();
            transform.position = playerPickup.transform.position + new Vector3(0, 5 , 0);
        }

        else
        {


            return;

        }
       
    }

    private void RotateArrow()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dropTarget.position - transform.position)
           , rotationSpeed * Time.deltaTime);
    }
}
