using System.Collections;
using UnityEngine;

public class Kite : MonoBehaviour,ISkillActor
{
    SkillsManager sm;
    SkillsParent sp;


    public GameObject Target { get; set; }
    public GameObject snapTarget { get; set; }



    void Start()
    {
        sm = GetComponentInParent<SkillsManager>();
        sp = GetComponentInParent<SkillsParent>();
    }

    public IEnumerator ActCoroutineFlow()
    {
        snapTarget = Target;
        yield return StartCoroutine(KiteFromTarget());

    }
    IEnumerator KiteFromTarget()
    {
        yield return null;

        Vector3 currentPos = sm.MainBody.transform.position;
        Vector3 targetPos = snapTarget.transform.position;

        // ターゲットから今の位置に向かって、その延長線上に逃げる（2倍分離れる）
        Vector3 awayPos = currentPos + (currentPos - targetPos).normalized * 1.0f;

        sm.MainBody.transform.position = Vector3.MoveTowards(
            currentPos,
            awayPos,
            sm.Parameter.MoveSpeed * sp.asbp.bp.msBuffPer * Time.deltaTime
        );
    }
}


