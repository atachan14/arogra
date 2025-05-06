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



    void Start()
    {
        sm = GetComponentInParent<SkillsManager>();
        sp = GetComponentInParent<SkillsParent>();
    }

    public IEnumerator ActCoroutineFlow() 
    {
        yield return StartCoroutine(ChaseToTarget());

    }

    IEnumerator ChaseToTarget()
    {
        yield return null;
        sm.MainBody.transform.position = Vector3.MoveTowards(
        sm.MainBody.transform.position,
        Target.transform.position,
        sm.Parameter.MoveSpeed * sp.asbp.bp.msBuffPer * Time.deltaTime
        );
    }
}
