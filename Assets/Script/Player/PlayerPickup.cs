using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform pickupPoint;

    public float sphereRadius = 1f;
    public LayerMask layerMask;

    private GameObject pickedObject = null;
    private Vector3 prevPosition;
    private Vector3 desirePos;

    public int maxHoldStrength;

    private PlayerMove playerMove;

    [HideInInspector]
    public bool isHolding;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        RaycastHit hit;
        bool isHit = Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, Mathf.Infinity, layerMask);
        if (isHit && !isHolding && playerMove.holdStrength > 0)
        {
            isHolding = true;



            pickedObject = hit.collider.gameObject;
            pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            pickedObject.GetComponent<CapsuleCollider>().isTrigger = true;
            prevPosition = pickedObject.transform.position;


            pickedObject.transform.position = Vector3.Lerp(prevPosition, pickupPoint.position, 0.5f * 
                Time.deltaTime);

            pickedObject.transform.parent = pickupPoint.transform;

            pickedObject.transform.localPosition = new Vector3(0, 0.3f, 0);
            pickedObject.transform.localRotation = Quaternion.Euler(90,0,0);
        }

        if(playerMove.pickedLost && pickedObject != null && playerMove.holdStrength <= 0)
        {
            isHolding = false;

            

            pickedObject.GetComponent<Rigidbody>().isKinematic = false;

            // Apply force to object based on player's movement
            
            pickedObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 6f);

            pickedObject.GetComponent<CapsuleCollider>().isTrigger = false;

            pickedObject.transform.parent = null;

            pickedObject = null;
        }
    }



}
