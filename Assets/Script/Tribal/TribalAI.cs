using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TribalAI : MonoBehaviour
{
    #region Variables

    public NavMeshAgent agent;

    public Transform targetPlayer;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject stonePrefab;

    public float stoneThrowSpeed;

    public GameObject directionArrow;

    public GameObject handPos;

    private float tribalSpeed;

    //animation triggers
    private bool isRun;
    private bool isAttacking;
    bool isWalking ;
    bool isDancing ;
    
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBtwAttacks;
    bool alreadyAttack;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    #endregion

    #region Private Methods
    private void Awake()
    {
        targetPlayer = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        stonePrefab.transform.position = handPos.transform.position;
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && !playerInSightRange)
        {

            Patroling();
            isWalking = true;
            isRun = false;
            isAttacking = false;
            isDancing = false;
            directionArrow.SetActive(false);
        }
        if (!playerInAttackRange && playerInSightRange)
        {
            Chasing();
            isRun = true;
            isAttacking = false;
            isDancing = false;
            directionArrow.SetActive(true);
        }
        if (playerInSightRange && playerInAttackRange )
        {
            Attacking();
            isWalking = false;
            isRun = false;
            isAttacking = true;
            isDancing = false;
            directionArrow.SetActive(true);
        }


        tribalSpeed = Random.Range(5.00f, 7.00f);
    }

    private void Patroling() 
    {
        


        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.speed = 3.5f;
            agent.SetDestination(walkPoint);
        

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        
    }

    private void SearchWalkPoint()
    {
        float numberZ = Random.Range(-walkPointRange, walkPointRange);
        float numberX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(walkPoint.x + numberX, walkPoint.y, walkPoint.z + numberZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        
    }
    private void Chasing()
    {
        agent.SetDestination(targetPlayer.position);
        agent.speed = tribalSpeed;
    }
    private void Attacking()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(targetPlayer);

        if (!alreadyAttack)
        {
            ///Attack code here
            ///
            /*Vector3 throwPos = new Vector3(transform.position.x - .5f,transform.position.y + 2f, transform.position.z);*/
            //attack animation

            

            isRun = false;
            isWalking = false;
            Rigidbody rb = Instantiate(stonePrefab, handPos.gameObject.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            

            rb.AddForce(transform.forward * stoneThrowSpeed, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            Destroy(rb.gameObject, 1.5f);
            ///End of attack code

            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBtwAttacks);
        }
    }

   /*private void Dancing()
    {
        if (isDancing)
        {
            isWalking = false;
            isRun = false;
            isAttacking = false;
        }
    }*/

    private void ResetAttack()
    {
        alreadyAttack = false;
    }

    public bool IsSprinting()
    {
        return isRun;
    }
    public bool DoingAttack()
    {
        return isAttacking;
    }

    #endregion
}
