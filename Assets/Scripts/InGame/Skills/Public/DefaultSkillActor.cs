using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DefaultSkillActor : MonoBehaviour, ISkillActor
{
    public SkillsManager SM { get; set; }
    public SkillsParent SP { get; set; }

    [SerializeField] public GameObject ac;
    [SerializeField] public GameObject AC { get =>ac ; set => ac = value; }

    public GameObject Target { get; set; }

    protected GameObject snapTarget;
    protected Vector3 snapScale;
    protected Vector3 snapPosition;
    protected Quaternion snapRotation;
    protected SSC snapState;

    void Start()
    {
        SM = GetComponentInParent<SkillsManager>();
        SP = GetComponentInParent<SkillsParent>();
        AC = transform.GetChild(0).gameObject;
    }

    public virtual IEnumerator ActCoroutineFlow()
    {
        SetupSnap();

        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MiddleFrame());
        yield return StartCoroutine(BackFrame());

        EndProcess();
       
    }

    protected virtual IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(SP.asbp.fp.frontFrame.value);
    }

    protected virtual IEnumerator MiddleFrame()
    {
        yield return new WaitForSeconds(SP.asbp.fp.middleFrame.value);
    }

    protected virtual IEnumerator BackFrame()
    {

        yield return new WaitForSeconds(SP.asbp.fp.backFrame.value);
    }

    protected virtual void EndProcess()
    {
        SM.SkillStateChange(SSC.Free);
    }

    protected void SetupSnap()
    {
        snapState = SM.State.SkillState;
        snapScale = transform.localScale;
        snapPosition = transform.localPosition;

        snapTarget = Target;

        if (snapTarget) LookTarget();
    }

    void LookTarget()
    {

        Vector3 targetPos = snapTarget.transform.position;
        Vector3 dir = targetPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        snapRotation = Quaternion.Euler(0, 0, angle);

        SM.MainBody.transform.rotation = snapRotation;
    }

}
