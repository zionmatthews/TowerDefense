using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health;

    public ScoreKeepingBehaviourScript scoreKeeping;

    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        scoreKeeping.score++;
        print("Enemy " + this.gameObject.name + " has died!");
        Destroy(this.gameObject);
    }
}
