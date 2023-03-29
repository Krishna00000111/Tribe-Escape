using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    [SerializeField]
    private int requiredLog;

    public GameObject boatPrefab;

    private int currentLogDetected;

    private void Start()
    {
        currentLogDetected = 0;
        boatPrefab.SetActive(false);
    }

    private void Update()
    {
        if(currentLogDetected == requiredLog)
        {
            Debug.Log("Spawn The Boat !!!");
            boatPrefab.SetActive(true);
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
