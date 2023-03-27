using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform pickupPoint;

    public Vector3 rayOrigin;

    public float rayDistance;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, Vector3.forward, out hit, rayDistance))
        {
            if(hit.collider.name == "Wood")
            {
                Debug.Log("Fuck");
            }
        }
    }

}
