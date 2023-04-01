using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform pickupPoint;

    public Transform sphereOrigin;

    public float sphereRadius;
    public LayerMask layerMask;

    private GameObject pickedObject = null;
    private Vector3 prevPosition;
    private Vector3 desirePos;

    public int maxHoldStrength;

    private PlayerMove playerMove;
    private PlayerDrop playerDrop;

    [HideInInspector]
    public bool isHolding;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerDrop = FindObjectOfType<PlayerDrop>();


    }

    private void Update()
    {
        RaycastHit hit;
        bool isHit = Physics.SphereCast(sphereOrigin.position, sphereRadius, Vector3.forward, out hit, 5f, layerMask);
        if (isHit && !isHolding && playerMove.holdStrength > 0)
        {
            isHolding = true;
            pickedObject = hit.collider.gameObject;
            pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            pickedObject.GetComponent<Collider>().isTrigger = true;
            pickedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            prevPosition = pickedObject.transform.position;


            pickedObject.transform.position = Vector3.Lerp(prevPosition, pickupPoint.position, 0.5f* 
                Time.deltaTime);

            pickedObject.transform.parent = pickupPoint.transform;

            pickedObject.transform.localPosition = new Vector3(0, 0.3f, 0);
            pickedObject.transform.localRotation = Quaternion.Euler(0,0,0);

        }

        if(playerMove.pickedLost && pickedObject != null && playerMove.holdStrength <= 0 )
        {
            isHolding = false;

            pickedObject.GetComponent<Rigidbody>().isKinematic = false;
            
            // Apply force to object based on player's movement

            Vector3 movement = pickedObject.transform.position;
            float forceMagnitude = Mathf.Clamp(0, 0, movement.magnitude * 5000);
            pickedObject.GetComponent<Rigidbody>().AddForce(movement.normalized * forceMagnitude *50);

            pickedObject.GetComponent<Collider>().isTrigger = false;

            pickedObject.transform.parent = null;

            playerMove.holdStrength = 2;

            pickedObject.layer = 0;

            pickedObject = null;
        }

        if (playerDrop.missionCompleted)
        {
            if (!isHolding) return;

            isHolding = false;

            pickedObject.GetComponent<Rigidbody>().isKinematic = false;

            // Apply force to object based on player's movement

            Vector3 movement = pickedObject.transform.position;
            float forceMagnitude = Mathf.Clamp(0, 0, movement.magnitude * 5000);
            pickedObject.GetComponent<Rigidbody>().AddForce(movement.normalized * forceMagnitude * 50);

            pickedObject.GetComponent<CapsuleCollider>().isTrigger = false;

            pickedObject.transform.parent = null;

            pickedObject.SetActive(false);

            pickedObject = null;


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            playerMove.holdStrength = 0;
        }
    }

}
