using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnim;
    public PlayerMove player;
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerAnim.SetBool("isRunning", player.IsRunning());
    }
}
