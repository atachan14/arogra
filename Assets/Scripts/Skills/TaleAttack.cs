using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TaleAttack : MonoBehaviour
{
    GameObject Parson;
    Parameter parameter;
    SkillsManager sm;
    ASBP asbp;

    [SerializeField] GameObject ac; //attackCollision
    SSCP sscp = SSCP.pri3;

    Vector3 targetPos;
    int stack = 0;

    void Start()
    {
        parameter = transform.root.GetComponentInChildren<Parameter>();
        sm = transform.parent.GetComponent<SkillsManager>();
        asbp = GetComponent<ASBP>();
        Parson = transform.root.gameObject;

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (sm.SkillStateCheck(sscp))
        {
            sm.SkillStateRequest(SSC.NowSkill);
            Exe(collision);
        }
    }

    void Exe(Collider2D collision)
    {
        Vector3 distance = collision.transform.position - transform.position;
        Vector3 direction = distance.normalized;
        targetPos = transform.position + distance + direction * 3f;

        StartCoroutine(ExeCoroutineFlow());
    }

    IEnumerator ExeCoroutineFlow()
    {
        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MiddleFrame());
        yield return StartCoroutine(BackFrame());
        sm.SkillStateRequest(SSC.Free);
        sm.CtReq(gameObject, asbp.Ct);
    }

    IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(asbp.FrontFrame);
    }

    IEnumerator MiddleFrame()
    {
        stack++;
        transform.position = Parson.transform.position;
        ac.transform.position = transform.position;

        Vector2 dir = targetPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float startAngle = angle - 30f;
        float endAngle = angle + 30f;
        if (stack == 3) { endAngle += angle + 360f; stack = 0; }

        ac.SetActive(true); 

        float duration = asbp.MiddleFrame;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, t);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
            yield return null;
        }
        ac.SetActive(false);
    }

    IEnumerator BackFrame()
    {

        yield return new WaitForSeconds(asbp.BackFrame);
    }
}
