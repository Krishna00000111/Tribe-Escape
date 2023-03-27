using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Variables

    private Animator playerAnim;
    public PlayerMove player;

    #endregion

    #region Private Methods
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerAnim.SetBool("isRunning", player.isRunning);
    }

    #endregion
}
