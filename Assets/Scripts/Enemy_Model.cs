using Sirenix.OdinInspector;
using UnityEngine;

public class Enemy_Model : Base_Model
{
    
    // 当前位置
    public Vector3 currentPos
    {
        get => transform.position;
    }
    
    [Title("巡逻相关")]
    public EnemyType EnemyType;
    [LabelText("巡逻移动最短距离")]
    public float minWanderDistance = 5;
    [LabelText("巡逻移动范围直径")]
    public float wanderDistance = 20f;
    [LabelText("巡逻点停止距离")]
    public float keepDistance = 0.1f;
    [LabelText("巡逻点停留时间")]
    public float delay = 0f;
    [LabelText("巡逻速度")]
    public float wanderSpeed;
    [LabelText("巡逻可视距离")]
    public float seekDistance;
    [LabelText("巡逻范围中心点")][ReadOnly]
    public Vector3 rootPos;

    [Title("追击相关")]
    [LabelText("追击速度")]
    public float pursueSpeed;
    [LabelText("追击脱离距离")]
    public float pursueDistance;

    
    [Title("攻击相关")]
    [LabelText("攻击冷却/攻速")]
    public float attackCooling = 5;
    [LabelText("攻击距离")]
    public float attackDistance;
    void Start()
    {
        rootPos = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rootPos,wanderDistance);
    }

    public override void Attack(Base_Model target)
    {
        target.TakeDamage(this.attackNum,this.attackDouble);
    }
}
