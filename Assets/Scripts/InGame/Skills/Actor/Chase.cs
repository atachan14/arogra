using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Chase : MonoBehaviour, ISkillActor
{
    SkillsManager sm;
    SkillsParent sp;


    public GameObject Target { get; set; }
    public GameObject snapTarget;



    void Start()
    {
        sm = GetComponentInParent<SkillsManager>();
        sp = GetComponentInParent<SkillsParent>();
    }

    public IEnumerator ActCoroutineFlow() 
    {
        snapTarget = Target;
        yield return StartCoroutine(ChaseToTarget());

    }

    IEnumerator ChaseToTarget()
    {
        if (Vector3.Distance(transform.position, snapTarget.transform.position) < 1f)
        {
            yield break;
        }

        yield return null;
        sm.MainBody.transform.position = Vector3.MoveTowards(
        sm.MainBody.transform.position,
        snapTarget.transform.position,
        sm.Parameter.MoveSpeed * sp.asbp.bp.msBuffPer.value * Time.deltaTime
        );
    }
}
