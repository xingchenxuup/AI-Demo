using Sirenix.OdinInspector;

[LabelText("敌人巡逻类型枚举")]
public enum EnemyType
{
    [LabelText("站桩")]
    Standstill,
    [LabelText("范围巡逻")]
    WanderInRange,
    [LabelText("线路巡逻")]
    WanderInLine,
    [LabelText("全图游荡")]
    Wander,
}
