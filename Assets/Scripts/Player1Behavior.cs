using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Behavior : MonoBehaviour
{
    [SerializeField]
    
    //Requires CharacterController Componet 
    private CharacterController controller;

    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        //The magnitude
        moveDirection *= speed;

        //Move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
