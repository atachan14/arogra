using UnityEngine;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class ToMultiAOE : DefaultTargetChecker
{
    public override bool SetupAndCheckTarget()
    {
        if (targetList.Count >= sp.asbp.rp.numOfPeaple.value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
