using System.Collections;
using UnityEngine;

public class SomethingThrow : MonoBehaviour
{
    SkillsManager SM;
    ASBP asbp;
    [SerializeField] GameObject ac;

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
    }

    IEnumerator FrontFrame()
    {
        yield return new WaitForSeconds(asbp.fp.frontFrame);
    }

    IEnumerator MiddleFrame()
    {
        yield return null;

        Vector3 targetPos = Target.transform.position;
        Vector3 dir = targetPos - transform.position;
       
        //çUåÇîªíËê∂ê¨ÅB
        GameObject item = Instantiate(ac);
        item.GetComponent<IThrowable>().ActThrow(dir,asbp.ap.throwSpeed);

    }

    IEnumerator BackFrame()
    {

        yield return new WaitForSeconds(asbp.fp.backFrame);
    }
}

