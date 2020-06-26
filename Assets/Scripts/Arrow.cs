using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Arrow Rigidbody
    Rigidbody myBody;

    //The arrows life timer
    private float lifeTimer = 4f;
    private float timer;

    private bool hitSomething = false;

    public float damage;

    private GameObject Enemy;

   
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        //once arrow reaches lifeTimer
        //It dies
         timer += Time.deltaTime;
        if(timer >= lifeTimer)
        {           
            Destroy(gameObject);
        }

        if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag != "Arrow")
        {
            hitSomething = true;
            //Sticks on collision
            Stick();
        }

        if (collision.transform.tag == "Enemy")
        {
            Enemy = collision.gameObject;
            Enemy.GetComponent<EnemyStats>().health -= damage;
        }

    }

    

    void Stick()
    {
        //Freezes all the arrows contraints 
       myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
