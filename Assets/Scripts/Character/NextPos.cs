using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.Timeline;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class NextPos : MonoBehaviour
{
    [SerializeField] GameObject Parson;
    [SerializeField] Parameter parameter;
    [SerializeField] State state;
    public Vector3 Value { get; set; }


    private void Start()
    {
        Value = transform.position;
    }


    void Update()
    {

        if (state.SkillState == SSC.Walk
               || state.SkillState == SSC.Run)
        {
            if (Vector3.Distance(Value, Parson.transform.position) > 0.01f)
            {
                WalkToNextPos();
            }
            else
            {
                state.SkillState = SSC.Free;
            }
        }

    }

    void WalkToNextPos()
    {
        Parson.transform.position = Vector3.MoveTowards(
        Parson.transform.position,
        Value,
        parameter.MoveSpeed * Time.deltaTime
        );
    }

}
