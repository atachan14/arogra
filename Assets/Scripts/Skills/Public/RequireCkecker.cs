using UnityEngine;

public class RequireCkecker : MonoBehaviour
{
    [SerializeField] SSCP need = SSCP.pri3;
    [SerializeField] private SSC change = SSC.NowSkill;

    public SSCP Need { get => need; set => need = value; }
    public SSC Change { get => change; set => change = value; }
    public float Ct { get; set; } = 0;

    private void Update()
    {
        if (Ct > 0)
        {
            Ct -= Time.deltaTime;
        }
    }

    public void AddCt(float num)
    {
        Ct += num;
    }
}
