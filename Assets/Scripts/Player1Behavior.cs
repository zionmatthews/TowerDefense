using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player1Behavior : MonoBehaviour
{
    [SerializeField]

    //Requires CharacterController Componet 
    private CharacterController controller;

    [SerializeField]
    private NavMeshAgent agent;

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

        ////Direction
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement.Normalize();


        controller.SimpleMove(movement);

        ////Move
        controller.SimpleMove(movement);
        agent.destination = transform.position + movement;



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
