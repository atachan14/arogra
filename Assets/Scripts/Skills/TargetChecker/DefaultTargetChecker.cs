using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultTargetChecker : MonoBehaviour, ITargetChecker
{
    protected SkillsParent sp;
    protected List<GameObject> targetList = new List<GameObject>();
    protected GameObject target = null;

    void Start()
    {
        sp = GetComponentInParent<SkillsParent>();
        SetupCollider();
    }

    void SetupCollider()
    {
        GetComponent<CircleCollider2D>().radius = sp.asbp.rp.targetRange;
        Debug.Log($"{this}SetupCollideräÆóπÅBsp:{sp}");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        targetList.Add(other.gameObject);
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        targetList.Remove(other.gameObject);
    }

    public abstract bool SetupAndCheckTarget();
}
