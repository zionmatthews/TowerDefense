﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimBehavior : MonoBehaviour
{
    private Animator animator;
 
    public bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attacking", attacking);
    }
}
