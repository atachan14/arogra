using UnityEngine;

[System.Serializable]
public class FrameParameter
{
    public float frontFrame;
    public float middleFrame;
    public float backFrame;
}

[System.Serializable]
public class RequireParameter
{
    public float targetRange;
    public float numOfPeaple;
    public float ct;
}

[System.Serializable]
public class ActParameter
{
    public float actCount;
    public float acRange;
}
public class ASBP : MonoBehaviour
{
    public FrameParameter fp;

    public RequireParameter rp;

    public ActParameter ap;


    //public float FrontFrame { get => frameParameter.frontFrame; set => frameParameter.frontFrame = value; }
    //public float MiddleFrame { get => frameParameter.middleFrame; set => frameParameter.middleFrame = value; }
    //public float BackFrame { get => frameParameter.backFrame; set => frameParameter.backFrame = value; }

    //public float ActRange { get => requireParameter.targetRange; set => requireParameter.targetRange = value; }
    //public float NumOfPeaple { get => requireParameter.numOfPeaple; set => requireParameter.numOfPeaple = value; }
    //public float Ct { get => requireParameter.ct; set => requireParameter.ct = value; }

    //public float NumOfTime { get => actParameter.numOfTime; set => actParameter.numOfTime = value; }
    //public float AttackRange { get => actParameter.attackRange; set => actParameter.attackRange = value; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
