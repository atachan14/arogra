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
public class DamegeParameter
{
    public OptionalFloat physicDamage;
    public OptionalFloat magicDamage;
}


    [System.Serializable]
public class ActParameter
{
    public float actCount;
    public float acRange;
    public float throwSpeed;
}



[System.Serializable]
public class BuffParameter
{
    public float msBuffPer;
}

public class ASBP : MonoBehaviour
{
    public FrameParameter fp;

    public RequireParameter rp;
    public DamegeParameter dp;

    public ActParameter ap;

    public BuffParameter bp;
}
