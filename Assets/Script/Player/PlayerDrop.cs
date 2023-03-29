using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    [SerializeField]
    private int requiredLog;

    public GameObject boatPrefab;
    private GameObject realPlayer;
    public Transform boatSeat;

    [HideInInspector]
    public bool onBoat;

    private int currentLogDetected;

    private void Start()
    {
        realPlayer = GameObject.Find("Player");
        currentLogDetected = 0;
        boatPrefab.SetActive(false);
    }

    private void Update()
    {
        if(currentLogDetected == requiredLog)
        {
            Debug.Log("Spawn The Boat !!!");
            boatPrefab.SetActive(true);
            onBoat = true;
            realPlayer.transform.position = boatSeat.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            currentLogDetected++;
        }
    }
}
