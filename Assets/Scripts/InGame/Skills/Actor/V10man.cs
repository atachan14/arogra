using System.Collections;
using UnityEngine;

public class V10man : DefaultSkillActor
{
    protected override IEnumerator MiddleFrame()
    {
        float duration = SP.asbp.fp.middleFrame.value / SP.asbp.ap.actCount.value / SP.asbp.ap.actCount.value;
        float numOfTime = SP.asbp.ap.actCount.value;

        AC.transform.localScale = new Vector3(SP.asbp.rp.targetRange.value * 2, SP.asbp.rp.targetRange.value * 2, 1);

        while (numOfTime > 0)
        {
            numOfTime--;
            AC.SetActive(true);
            yield return new WaitForSeconds(duration);

            AC.SetActive(false);
            yield return new WaitForSeconds(duration);
        }
    }
}
