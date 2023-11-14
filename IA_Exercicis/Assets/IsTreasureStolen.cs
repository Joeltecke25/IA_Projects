using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Treasure Stolen?")]
[Help("Checks whether Cop is near the Treasure.")]
public class IsTreasureStolen : ConditionBase
{
    [InParam("Treasure")]
    [Help("Treasure")]
    public GameObject treasure;

    public override bool Check()
    {
        if (!treasure.activeInHierarchy)
        {
            return true;
        }
        else return false;
    }
}