using System.Collections;
using UnityEngine;

public class V10man : DefaultSkillActor
{
    protected override IEnumerator MiddleFrame()
    {
        float duration = SP.asbp.fp.middleFrame / SP.asbp.ap.actCount / 2;
        float numOfTime = SP.asbp.ap.actCount;

        ac.transform.localScale = new Vector3(SP.asbp.rp.targetRange * 2, SP.asbp.rp.targetRange * 2, 1);

        while (numOfTime > 0)
        {
            numOfTime--;
            ac.SetActive(true);
            yield return new WaitForSeconds(duration);

            ac.SetActive(false);
            yield return new WaitForSeconds(duration);
        }

    }


}
