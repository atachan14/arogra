using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Denkousekka : MonoBehaviour,ISkillActor
{
    SkillsManager SM;
    ASBP asbp;
    GameObject MainBody;
    GameObject ac;

    public GameObject Target { get; set; }

    Vector3 targetPos;
    Vector3 distance;

    void Start()
    {
        SM = GetComponentInParent<SkillsManager>();
        asbp = transform.parent.GetComponentInChildren<ASBP>();
        MainBody = transform.root.gameObject;
        ac = transform.GetChild(0).gameObject;

    }


    public IEnumerator ActCoroutineFlow()
    {
        Vector3 distance = Target.transform.position - transform.position;
        Vector3 direction = distance.normalized;
        targetPos = transform.position + distance + direction * 3f;

        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MiddleFrame());
        yield return StartCoroutine(BackFrame());
        SM.SkillStateChange(SSC.Free);
    }

    IEnumerator FrontFrame()
    {
        float duration = asbp.FrontFrame;
        float timer = 0f;

        Vector3 startScale = MainBody.transform.localScale;
        Vector3 endScale = new Vector3(startScale.x, startScale.y * 0.4f, startScale.z);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            MainBody.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        MainBody.transform.localScale = endScale;
    }

    IEnumerator MiddleFrame()
    {
        //体のサイズ
        Vector3 startScale = MainBody.transform.localScale;
        MainBody.transform.localScale = new Vector3(startScale.x * 1.6f, startScale.y, startScale.z);

        //時間設定
        float duration = asbp.MiddleFrame;
        float timer = 0f;

        //位置設定
        distance = MainBody.transform.position - targetPos;
        Vector3 startPos = MainBody.transform.position;

        //攻撃判定Active
        ac.SetActive(true);

        //実行
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            MainBody.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        //到着
        MainBody.transform.position = targetPos;
    }

    IEnumerator BackFrame()
    {
        ac.SetActive(false);
        MainBody.transform.localScale = SM.Parameter.NaturalSize();
        yield return new WaitForSeconds(asbp.BackFrame);
        


    }
}
