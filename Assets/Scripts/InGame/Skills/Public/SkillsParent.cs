using UnityEngine;

public class SkillsParent : MonoBehaviour
{
    [SerializeField] string skillID;
    public ITargetChecker tc { get; set; }
    public RequireCkecker rc { get; set; }
    public ISkillActor sa { get; set; }

    public SkillParameter asbp;

    void Awake()
    {
        asbp = SBPDB.Get(skillID);
        tc = GetComponentInChildren<ITargetChecker>();
        rc = GetComponentInChildren<RequireCkecker>();
        sa = GetComponentInChildren<ISkillActor>();
    }

}
