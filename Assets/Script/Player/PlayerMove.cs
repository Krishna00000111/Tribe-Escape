using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Variables

    [SerializeField] private float moveSpeed;

    public Joystick joystick;

    private Rigidbody player_rb;

    private float horizonrtalInput;
    private float verticalInput;

    [HideInInspector]
    public bool isRunning;

    #endregion


    #region Private Methods
    private void Start()
    {
        player_rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    
    private void HandleMovement()
    {
        horizonrtalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;

        player_rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, player_rb.velocity.y,
            joystick.Vertical * moveSpeed);
        
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(player_rb.velocity);

            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    #endregion 
}
