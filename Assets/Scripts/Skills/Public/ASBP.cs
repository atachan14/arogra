using UnityEngine;

public class ASBP : MonoBehaviour //AttacjSkillBaseParameter
{
    [SerializeField] float frontFrame;
    [SerializeField] float middleFrame;
    [SerializeField] float backFrame;
    [SerializeField] float ct;
    [SerializeField] float actRange;


    public float FrontFrame { get => frontFrame; set => frontFrame = value; }
    public float MiddleFrame { get => middleFrame; set => middleFrame = value; }
    public float BackFrame { get => backFrame; set => backFrame = value; }
    public float Ct { get => ct; set => ct = value; }
    public float ActRange { get => actRange; set => actRange = value; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
