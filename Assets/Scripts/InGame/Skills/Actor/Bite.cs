using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Bite : DefaultSkillActor
{
    protected override IEnumerator FrontFrame()
    {

        float duration = SP.asbp.fp.frontFrame.value;
        float timer = 0f;

        float startY = 1;
        float endY = 2;

        while (timer < duration / 2)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            Vector3 scale = snapScale;
            scale.y *= Mathf.Lerp(startY, endY, t);
            SM.MainBody.transform.localScale = scale;

            yield return null;
        }

        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }

    protected override IEnumerator MiddleFrame()
    {
        SM.MainBody.transform.localScale = snapScale;
        Instantiate(ac,transform);

        yield return new WaitForSeconds(SP.asbp.fp.middleFrame.value);
    }
}
