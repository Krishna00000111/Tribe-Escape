using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public Joystick joystick;

    private Rigidbody player_rb;

    //public float gravity;

    private float horizonrtalInput;
    private float verticalInput;

    private bool isRunning;

    //private bool isGrounded;

    //public LayerMask groundLayer;

    //private float raycastDistance = 0.05f;

    public Transform groundChecker;

    private void Start()
    {
        player_rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HandleMovement();

        //Gravity();
    }


    private void HandleMovement()
    {
        horizonrtalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;

        Vector3 inputVector = new Vector3(0, 0, 0);

        if (verticalInput > 0.1f)
        {
            inputVector.z = +1;
         
        }

        if (verticalInput < -0.1f)
        {
            inputVector.z = -1;
            
        }

        if (horizonrtalInput < -0.1f)
        {
            inputVector.x = -1;
           
        }

        if (horizonrtalInput > 0.1f)
        {
            inputVector.x = +1;
            
        }

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.z);

        isRunning = moveDir.magnitude > 0;

        float rotationSpeed = 8f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);

        transform.position += inputVector * Time.deltaTime * moveSpeed;
        
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    /*private void Gravity()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundChecker.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            isGrounded = false;
            Debug.Log("In The Air");
            //player_rb.AddForce(Vector3.down * gravity * Time.deltaTime, ForceMode.Impulse);
        }
    }*/
}
