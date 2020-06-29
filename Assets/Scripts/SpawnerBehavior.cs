using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// spawns in objects
/// 
public class SpawnerBehavior : MonoBehaviour
{
    /// 
    /// thing that's being spawned in
    /// 
    public GameObject objectToSpawn;
    /// 
    /// behavoir given to target
    /// 
    public Transform behaviorTarget;

    /// 
    /// how often they spawn
    /// 
    public float timeInterval = 5.0f;
    /// 
    /// how long until the next thing spawns
    /// 
    public float timeRemaining = 0;

    public ScoreKeepingBehaviourScript scoreKeeping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = timeInterval;
            SpawnInstance();
        }
    }

    void SpawnInstance()
    {
        GameObject spawnedEnemy = Instantiate(objectToSpawn, transform.position, transform.rotation);
        PathfindBehavior pathfindBehavior = spawnedEnemy.GetComponent<PathfindBehavior>();
        if (pathfindBehavior != null)
        {
            pathfindBehavior.target = behaviorTarget;
        }
        EnemyStats enemyStats = spawnedEnemy.GetComponent<EnemyStats>();
        if (enemyStats != null)
        {
            enemyStats.scoreKeeping = scoreKeeping;
        }
    }
}
