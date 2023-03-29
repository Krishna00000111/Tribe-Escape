using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Variables

    private Animator playerAnim;
    private int holdLayerIndex;

    private  PlayerMove player;
    private PlayerPickup playerPickup;
    private PlayerDrop playerDrop;

    float targetLayerValue = 1;
    #endregion

    #region Private Methods

    
    void Awake()
    {
        player = GetComponentInParent<PlayerMove>();
        playerPickup = GetComponentInParent<PlayerPickup>();
        playerDrop = FindObjectOfType<PlayerDrop>();
        playerAnim = GetComponent<Animator>();
        holdLayerIndex = playerAnim.GetLayerIndex("UpperBody");
    }

    private void Update()
    {
        playerAnim.SetBool("isRunning", player.isRunning);

        playerAnim.SetBool("onBoat", playerDrop.onBoat);


        if (playerPickup.isHolding)
        {
            playerAnim.SetLayerWeight(holdLayerIndex, targetLayerValue);
        }
        else
        {
            playerAnim.SetLayerWeight(holdLayerIndex, 0);
        }

    }

    #endregion
}
