using UnityEngine;

public class SkillsParent : MonoBehaviour
{
    public ITargetChecker tc { get; set; }
    public RequireCkecker rc { get; set; }
    public ISkillActor sa { get; set; }
    public ASBP asbp { get; set; }

    void Start()
    {
        tc = GetComponentInChildren<ITargetChecker>();
        rc = GetComponentInChildren<RequireCkecker>();
        sa = GetComponentInChildren<ISkillActor>();
        asbp = GetComponentInChildren<ASBP>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
