using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RewindablePlayer : Rewindable
{
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Rewind()
    {
        base.Rewind();
        animator.enabled = pointsInTime.Count <= 0;
    }

}
