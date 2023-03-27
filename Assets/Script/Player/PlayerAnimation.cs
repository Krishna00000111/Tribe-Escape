using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Variables

    private Animator playerAnim;
    private int holdLayerIndex;

    public PlayerMove player;

    float targetLayerValue = 1;

    #endregion

    #region Private Methods
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        holdLayerIndex = playerAnim.GetLayerIndex("UpperBody");
    }

    private void Update()
    {
        playerAnim.SetBool("isRunning", player.isRunning);

        if (player.isHolding)
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
