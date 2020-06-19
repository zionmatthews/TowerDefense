using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviourScript : MonoBehaviour
{
    public float towerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
        enemyAttack(); 
        //other.gameObject.
        }
    }

    void enemyAttack()
    {
        towerHealth-= Time.fixedDeltaTime;
    }
}
