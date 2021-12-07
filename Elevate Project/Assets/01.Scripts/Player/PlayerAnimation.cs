using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerInput input;
    Animator animator;

    private float move;
    private readonly int hashIsMove = Animator.StringToHash("isMove");
   
    void Start()
    {
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move = input.move;
        MoveAnimation();
    }

    private void MoveAnimation()
    {
        if (move > 0 || move < 0) {
            animator.SetBool(hashIsMove, true);
        } else {
            animator.SetBool(hashIsMove, false);
        }
    }
}
