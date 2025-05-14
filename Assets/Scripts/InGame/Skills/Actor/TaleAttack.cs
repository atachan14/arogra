using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TaleAttack : MonoBehaviour,ISkillActor
{
    SkillsManager SM;
    SkillParameter asbp;
    [SerializeField] GameObject ac;

    public GameObject Target { get; set; }

    int stack = 0;

    void Start()
    {
        SM = GetComponentInParent<SkillsManager>();
        asbp = transform.parent.GetComponentInChildren<SkillParameter>();
    }



    public IEnumerator ActCoroutineFlow()
    {
        yield return StartCoroutine(FrontFrame());
        yield return StartCoroutine(MiddleFrame());
        yield return StartCoroutine(BackFrame());
        SM.SkillStateChange(SSC.Free);
    }

    IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(asbp.fp.frontFrame.value);
    }

    IEnumerator MiddleFrame()
    {
        //transform�ۑ�
        Vector3 startTransform = transform.position;
        Vector3 startACTransformac = ac.transform.position;

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
        float duration = asbp.fp.middleFrame.value;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, t);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
            yield return null;
        }

        //transform����
        transform.position = startTransform;
        ac.transform.position = startACTransformac;

        ac.SetActive(false);
    }

    IEnumerator BackFrame()
    {

        yield return new WaitForSeconds(asbp.fp.backFrame.value );
    }
}
