using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToNearst : DefaultTargetChecker
{
    public override bool SetupTarget()
    {
        if (targetList.Count > 0)
        {
            target = targetList
                .Where(t => t != null)
                .OrderBy(t => Vector3.Distance(t.transform.position, transform.position))
                .FirstOrDefault();
        }
        else
        {
            target = null;
        }

        sp.sa.Target = target;
        return target != null;
    }
}
