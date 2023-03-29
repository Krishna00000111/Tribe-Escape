using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    [SerializeField]
    private int requiredLog;

    private int currentLogDetected;

    private void Start()
    {
        currentLogDetected = 0;
    }

    private void Update()
    {
        if(currentLogDetected == requiredLog)
        {
            Debug.Log("Spawn The Boat !!!");
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
