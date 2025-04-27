using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public SSC SkillState { get; set; } = SSC.Free;
    public Dictionary<SSCP, HashSet<SSC>> sscpDict = new Dictionary<SSCP, HashSet<SSC>>()
{
    { SSCP.pri1, new HashSet<SSC> { SSC.Free } },
    { SSCP.pri2, new HashSet<SSC> { SSC.Free, SSC.Walk } },
    { SSCP.pri3, new HashSet<SSC> { SSC.Free, SSC.Walk, SSC.CanSkill } },
};

    public bool CheckSSCP(SSCP pri)
    {
        return sscpDict[pri].Contains(SkillState);
    }
}
