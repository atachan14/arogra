using UnityEngine;

[System.Serializable]
public class FrameParameter
{
    public OptionalFloat frontFrame;
    public OptionalFloat middleFrame;
    public OptionalFloat acFrame;
    public OptionalFloat backFrame;
}

[System.Serializable]
public class RequireParameter
{
    public OptionalFloat targetRange;
    public OptionalFloat numOfPeaple;
    public OptionalFloat ct;
}

[System.Serializable]
public class DamageParameter
{
    public OptionalFloat physicDamage;
    public OptionalFloat electDamage;
    public OptionalFloat flostDamage;
    public OptionalFloat darkDamage;
}


    [System.Serializable]
public class ActParameter
{
    public OptionalFloat actCount;
    public OptionalFloat acRange;
    public OptionalFloat bulletSpeed;
}



[System.Serializable]
public class BuffParameter
{
    public OptionalFloat msBuffPer;
}

public class SkillParameter 
{
    public FrameParameter fp;

    public RequireParameter rp;

    public DamageParameter dp;

    public ActParameter ap;

    public BuffParameter bp;
}
