using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribalAnimation : MonoBehaviour
{
    private Animator tri_Anim;
    public TribalAI tribal;
    private void Start()
    {
        tri_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        tri_Anim.SetBool("isRun", tribal.IsSprinting());

        tri_Anim.SetBool("isAttacking", tribal.DoingAttack());

        //tri_Anim.SetBool("isDancing", tribal.isDancing);
    }
}
