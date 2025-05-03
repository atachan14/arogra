using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SkillsManager : MonoBehaviour
{

    public MainBody MainBody { get; set; }
    public BodySprite BodySprite { get; set; }
    public BasicParameter Parameter { get; set; }
    public NowState State { get; set; }

    List<GameObject> SkillList = new List<GameObject>();
    Dictionary<GameObject, float> CtDict = new Dictionary<GameObject, float>();
   
    void Start()
    {
        MainBody = GetComponentInParent<MainBody>();
        BodySprite = MainBody.GetComponentInChildren<BodySprite>();
        Parameter = MainBody.GetComponentInChildren<BasicParameter>();
        State = MainBody.GetComponentInChildren<NowState>();

        CreateSkillList();

    }

    void CreateSkillList()
    {
        SkillList = transform.Cast<Transform>()
            .Where(t => t.gameObject.activeSelf)
            .Select(t => t.gameObject)
            .ToList();
    }

    private void Update()
    {
        if (SkillList.Count != 0)
        {
            RunSkillList();
        }
    }

    void RunSkillList()
    {
        foreach (GameObject skill in SkillList)
        {
            if(!CheckersWork(skill)) continue;
            StartCoroutine(DecideWork(skill));
        }
    }

    bool CheckersWork(GameObject skill)
    {
        var tc = skill.GetComponentInChildren<ITargetChecker>();
        if (!tc.SetupAndCheckTarget()) return false;

        var rc = skill.GetComponentInChildren<RequireCkecker>();
        if (rc.Ct > 0) return false;


        if (!SkillStateCheck(rc.Need)) return false;

        Debug.Log($"{skill}î≠âŒÅBSkillState:{State.SkillState}");
        return true;

        
    }

    IEnumerator DecideWork(GameObject skill)
    {
        var rc = skill.GetComponentInChildren<RequireCkecker>();
        var executor = skill.GetComponentInChildren<ISkillActor>();
        var asbp = skill.GetComponentInChildren<ASBP>();

        SkillStateChange(rc.Change);
        yield return StartCoroutine(executor.ActCoroutineFlow());
        rc.AddCt(asbp.rp.ct);
    }


    public void LayerSetting(LayerMask campType)
    {
        gameObject.layer = UnityEngine.LayerMask.NameToLayer(campType.ToString());
        foreach (var checker in GetComponentsInChildren<ITargetChecker>())
        {
            var component = checker as Component;
            if (component != null)
            {
                component.gameObject.layer = gameObject.layer;
            }
        }
    }

    public bool SkillStateCheck(HashSet<SSC> sscSet)
    {
        return sscSet.Contains(State.SkillState);
    }

    public bool SkillStateCheck(SSCP sscp)
    {
        return State.CheckSSCP(sscp);
    }

    public void SkillStateChange(SSC value)
    {
        State.SkillState = value;
    }

    //public void CtReq(GameObject skill, float ct)
    //{
    //    CtDict.Add(skill, ct);
    //}
}
