using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Chase : MonoBehaviour
{
    GameObject Parson;
    BasicParameter bs;
    SkillsManager sm;

    SSCP sscp = SSCP.pri3;

    List<GameObject> targetList = new List<GameObject>();
    GameObject target;

    float moveSpeedBuffPer = 1.5f;
    void Start()
    {
        bs = transform.root.GetComponentInChildren<BasicParameter>();
        sm = transform.parent.GetComponent<SkillsManager>();
        Parson = transform.root.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetList.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetList.Remove(other.gameObject);
    }

    void Update()
    {
        if (targetList.Count > 0)
        {
            target = targetList
                .Where(t => t != null)
                .OrderBy(t => Vector3.Distance(t.transform.position, transform.position))
                .FirstOrDefault();

            if (target != null
                && Vector3.Distance(target.transform.position, transform.position) > 1.5f
                && sm.SkillStateCheck(sscp))
            {
                sm.SkillStateChange(SSC.CanSkill);
                ChaseToTarget();
            }
        }
    }

    void ChaseToTarget()
    {
        Parson.transform.position = Vector3.MoveTowards(
        Parson.transform.position,
        target.transform.position,
        bs.MoveSpeed * moveSpeedBuffPer * Time.deltaTime
        );
    }
}
