using Sirenix.OdinInspector;
using UnityEngine;

public class Base_Model : MonoBehaviour
{
    [Title("基础属性")] 
    [LabelText("生命值")][SerializeField]
    protected float hp;
    
    [Title("攻击属性")]
    [LabelText("攻击力")][SerializeField]
    protected float attackNum;
    [LabelText("暴击率")][SerializeField]
    protected float attackDouble;

    [Title("防御属性")]
    [LabelText("防御力")][SerializeField]
    protected float defenseNum;

    public void TakeDamage(float attackerNum,float attackerDouble)
    {
        var range = Random.Range(0f, 1f);
        var attackNumber = attackerNum;
        if (range <= attackerDouble)
        {
            attackNumber *= 2;
            Debug.Log("暴击");
        }
        this.hp -= (attackNumber - defenseNum);
        Debug.Log("TakeDamage");
    }
    
    public virtual void Attack(Base_Model target)
    {
        
    }
    
}
