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
    public Vector3 currentPos
    {
        get => transform.position;
    }

    [Header("追击相关")] 
    public float pursueSpeed;
    
    [Header("攻击相关")]
    public float attackCooling;
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


    public void Attack()
    {
        Debug.Log("attack");
    }
}
