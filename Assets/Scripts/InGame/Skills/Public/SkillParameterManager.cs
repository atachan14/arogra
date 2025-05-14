using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillParameterManager : MonoBehaviour
{

    public SkillParameter baseParameter;

    public SkillParameter parameter;
    public SkillParameter Get()
    {
        return parameter;
    }
}

