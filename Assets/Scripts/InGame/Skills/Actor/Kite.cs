using System.Collections;
using UnityEngine;

public class Kite : DefaultSkillActor
{

    protected override IEnumerator MiddleFrame()
    {
        yield return null;

        Vector3 currentPos = SM.MainBody.transform.position;
        Vector3 targetPos = snapTarget.transform.position;

        // ターゲットから今の位置に向かって、その延長線上に逃げる（2倍分離れる）
        Vector3 awayPos = currentPos + (currentPos - targetPos).normalized * 1.0f;

        SM.MainBody.transform.position = Vector3.MoveTowards(
            currentPos,
            awayPos,
            SM.Parameter.MoveSpeed * SP.asbp.bp.msBuffPer * Time.deltaTime
        );
    }
}


