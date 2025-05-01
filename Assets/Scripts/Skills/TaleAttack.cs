using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TaleAttack : MonoBehaviour,ISkillActor
{
    SkillsManager SM;
    
    ASBP asbp;
    [SerializeField] GameObject ac; //attackCollision

    public GameObject Target { get; set; }

    int stack = 0;

    void Start()
    {
        SM = GetComponentInParent<SkillsManager>();
        asbp = transform.parent.GetComponentInChildren<ASBP>();
    }



    public IEnumerator ActCoroutineFlow()
    {
        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MiddleFrame());
        yield return StartCoroutine(BackFrame());
        SM.SkillStateChange(SSC.Free);
        //SM.CtReq(gameObject, asbp.Ct);
    }

    IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(asbp.FrontFrame);
    }

    IEnumerator MiddleFrame()
    {
        transform.position = SM.MainBody.transform.position;
        ac.transform.position = transform.position;

        stack++;

        //���[�����Ƃ̈ʒu�m�F�B
        Vector3 targetPos = Target.transform.position;
        Vector2 dir = targetPos - transform.position;

        //���񂮂�ݒ�B
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float startAngle = angle - 30f;
        float endAngle = angle + 30f;
        if (stack == 3) { endAngle += angle + 360f; stack = 0; }

        //�U������Active�B
        ac.SetActive(true); 

        //���Ԃ����Ă��B
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
