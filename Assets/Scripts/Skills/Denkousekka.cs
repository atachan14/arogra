using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Denkousekka : MonoBehaviour
{

    GameObject Parson;
    Parameter parameter;
    SkillsManager sm;
    ASBP asbp;

    SSCP sscp = SSCP.pri3;

    Vector3 distance;
    Vector3 targetPos;

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
        float duration = asbp.FrontFrame;
        float timer = 0f;

        Vector3 startScale = Parson.transform.localScale;
        Vector3 endScale = new Vector3(startScale.x, startScale.y * 0.4f, startScale.z);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            Parson.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        Parson.transform.localScale = endScale;
    }

    IEnumerator MiddleFrame()
    {

        Vector3 startScale = Parson.transform.localScale;
        Parson.transform.localScale = new Vector3(startScale.x * 1.6f, startScale.y, startScale.z);

        float duration = 0.2f;
        float timer = 0f;

        distance = Parson.transform.position - targetPos;
        Vector3 startPos = Parson.transform.position;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            Parson.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        Parson.transform.position = targetPos;
    }

    IEnumerator BackFrame()
    {
        Parson.transform.localScale = parameter.NaturalSize();
        yield return new WaitForSeconds(asbp.BackFrame);
        


    }
}
