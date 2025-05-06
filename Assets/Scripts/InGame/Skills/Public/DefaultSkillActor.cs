using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultSkillActor : MonoBehaviour, ISkillActor
{
    public SkillsManager SM { get; set; }
    public SkillsParent SP { get; set; }

    [SerializeField] public GameObject ac { get; set; }

    public GameObject Target { get; set; }
    protected GameObject snapTarget;

    void Start()
    {
        SM = GetComponentInParent<SkillsManager>();
        SP = GetComponentInParent<SkillsParent>();
        ac = transform.GetChild(0).gameObject;
    }

    public virtual IEnumerator ActCoroutineFlow()
    {
        snapTarget = Target;
        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MiddleFrame());
        yield return StartCoroutine(BackFrame());
        SM.SkillStateChange(SSC.Free);
    }

    protected virtual IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(SP.asbp.fp.frontFrame);
    }

    protected virtual IEnumerator MiddleFrame()
    {
        yield return new WaitForSeconds(SP.asbp.fp.middleFrame);
    }

    protected virtual IEnumerator BackFrame()
    {

        yield return new WaitForSeconds(SP.asbp.fp.backFrame);
    }

}
