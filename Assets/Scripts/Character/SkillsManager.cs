using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    State state;
    Dictionary<GameObject, float> CtDict = new Dictionary<GameObject, float>();
    List<GameObject> SkillList = new List<GameObject>();

    void Start()
    {
        state = transform.root.GetComponentInChildren<State>();
    }

    private void Update()
    {
        if (CtDict.Count != 0)
        {
            CtCount();
        }


    }

    void CtCount()
    {
        var keys = CtDict.Keys.ToList();
        foreach (var skill in keys)
        {
            CtDict[skill] -= Time.deltaTime;
            if (CtDict[skill] <= 0f)
            {
                skill.SetActive(true);
                CtDict.Remove(skill);
            }
        }
    }

    public void LayerSetting(CampType campType)
    {
        gameObject.layer = LayerMask.NameToLayer(campType.ToString());
        foreach (Transform child in transform)
        {
            child.gameObject.layer = gameObject.layer;
        }
    }

    public bool SkillStateCheck(HashSet<SSC> sscSet)
    {
        return sscSet.Contains(state.SkillState);
    }

    public bool SkillStateCheck(SSCP sscp)
    {
        return state.CheckSSCP(sscp);
    }

    public void SkillStateRequest(SSC value)
    {
        state.SkillState = value;
    }

    public void CtReq(GameObject skill, float ct)
    {
        CtDict.Add(skill, ct);
        skill.SetActive(false);
    }
}
