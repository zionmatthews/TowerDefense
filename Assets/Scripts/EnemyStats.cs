using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health;

    

    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        print("Enemy " + this.gameObject.name + " has died!");
        Destroy(this.gameObject);
    }
}
