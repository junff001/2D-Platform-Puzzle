using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private PlayerInput input;

    private bool interaction;
    private readonly int hashIsSwitch = Animator.StringToHash("isSwitch");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        interaction = input.interaction;
        OnSwitch();
    }

    private void OnSwitch()
    {
        if (interaction) {
            animator.SetBool(hashIsSwitch, true);
        } else {
            animator.SetBool(hashIsSwitch, false);
        }
    }
}
