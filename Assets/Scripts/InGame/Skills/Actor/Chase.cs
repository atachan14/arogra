using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Chase : DefaultSkillActor
{

    protected override IEnumerator MiddleFrame()
    {
        yield return null;

        if (Vector3.Distance(transform.position, snapTarget.transform.position) < 1.5f)
        {
            yield break;
        }

        SM.MainBody.transform.position = Vector3.MoveTowards(
        SM.MainBody.transform.position,
        snapTarget.transform.position,
        SM.Parameter.MoveSpeed * SP.asbp.bp.msBuffPer * Time.deltaTime
        );
    }
}
