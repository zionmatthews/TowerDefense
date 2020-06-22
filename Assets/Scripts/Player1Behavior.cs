﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player1Behavior : MonoBehaviour
{
    [SerializeField]

    //Requires CharacterController Componet 
    private CharacterController controller;

    //Players speed
    public float speed = 5.0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Camera gameObject
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        //Player looks at mouse position
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        //Direction
        Vector3 moveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) //Up
            moveDirection += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.A)) //Left
            moveDirection += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.S)) //Down
            moveDirection += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.D)) //Right
            moveDirection += new Vector3(1, 0, 0);

        moveDirection.Normalize();

        //Set the magnitude
        moveDirection *= speed;

        //Move
        controller.Move(moveDirection * Time.deltaTime);


        //Player rotation
        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }       
    }
}