using System.Collections;
using UnityEngine;

public class Denkousekka : MonoBehaviour,ISkillActor
{
    SkillsManager SM;
    ASBP asbp;
    GameObject ac;

    public GameObject Target { get; set; }

    Vector3 targetPos;
    Vector3 distance;

    void Start()
    {
        SM = GetComponentInParent<SkillsManager>();
        asbp = transform.parent.GetComponentInChildren<ASBP>();
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
        float duration = asbp.fp.frontFrame;
        float timer = 0f;

        Vector3 startScale = SM.BodySprite.transform.localScale;
        Vector3 endScale = new Vector3(startScale.x, startScale.y * 0.4f, startScale.z);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            SM.BodySprite.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        SM.BodySprite.transform.localScale = endScale;
    }

    IEnumerator MiddleFrame()
    {
        //�̂̃T�C�Y
        Vector3 startScale = SM.BodySprite.transform.localScale;
        SM.BodySprite.transform.localScale = new Vector3(startScale.x * 1.6f, startScale.y, startScale.z);

        //���Ԑݒ�
        float duration = asbp.fp.middleFrame;
        float timer = 0f;

        //�ʒu�ݒ�
        distance = SM.BodySprite.transform.position - targetPos;
        Vector3 startPos = SM.MainBody.transform.position;

        //�U������Active
        ac.SetActive(true);

        //���s
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            SM.MainBody.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        //����
        SM.MainBody.transform.position = targetPos;
    }

    IEnumerator BackFrame()
    {
        ac.SetActive(false);
        SM.BodySprite.transform.localScale = SM.Parameter.NaturalSize();
        yield return new WaitForSeconds(asbp.fp.backFrame);
        


    }
}
