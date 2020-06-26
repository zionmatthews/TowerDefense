using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviourScript : MonoBehaviour
{
    public float towerMaxHealth = 100;
    public float towerCurrentHealth = 100;
    public HealthBarBehaviourScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        towerCurrentHealth = towerMaxHealth;
        healthBar.SetMaxHealth(Convert.ToInt32(towerMaxHealth));
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
        towerCurrentHealth-= Time.fixedDeltaTime;

        healthBar.SetMaxHealth(Convert.ToInt32(towerCurrentHealth));
    }
}
