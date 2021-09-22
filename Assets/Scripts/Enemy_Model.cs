using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Model : MonoBehaviour
{

    // public Test test;
    public EnemyType EnemyType;

    [Header("巡逻相关")]
    public float minWanderDistance = 5;
    public float wanderDistance = 20f;
    public float keepDistance = 0.1f;
    public float delay = 0f;
    public float wanderSpeed;
    public Vector3 rootPos;
    [Header("追击相关")] 
    public float pursueSpeed;
    void Start()
    {
        rootPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rootPos,wanderDistance);
    }
}
