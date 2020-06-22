using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// 
/// used to move to a target
///
public class PathfindBehavior : MonoBehaviour
{
    /// 
    /// thing being navagated to
    /// 
    public Transform target;
    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
    }

}
