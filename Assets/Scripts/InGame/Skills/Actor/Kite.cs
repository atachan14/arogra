using System.Collections;
using UnityEngine;

public class Kite : DefaultSkillActor
{

    protected override IEnumerator MiddleFrame()
    {
        yield return null;

        Vector3 currentPos = SM.MainBody.transform.position;
        Vector3 targetPos = snapTarget.transform.position;

        // �^�[�Q�b�g���獡�̈ʒu�Ɍ������āA���̉�������ɓ�����i2�{�������j
        Vector3 awayPos = currentPos + (currentPos - targetPos).normalized * 1.0f;

        SM.MainBody.transform.position = Vector3.MoveTowards(
            currentPos,
            awayPos,
            SM.Parameter.MoveSpeed * SP.asbp.bp.msBuffPer * Time.deltaTime
        );
    }
}


