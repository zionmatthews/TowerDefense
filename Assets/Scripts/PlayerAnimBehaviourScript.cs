﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimBehaviourScript : MonoBehaviour
{
    private Animator animator;

    public NavMeshAgent agent;

    public Bow bow;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        animator.SetBool("New Bool", bow.PlayerFire);
    }
}