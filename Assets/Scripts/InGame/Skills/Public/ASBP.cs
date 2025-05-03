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

[System.Serializable]
public class BuffParameter
{
    public float msBuffPer;
}

public class ASBP : MonoBehaviour
{
    public FrameParameter fp;

    public RequireParameter rp;

    public ActParameter ap;

    public BuffParameter bp;
}
