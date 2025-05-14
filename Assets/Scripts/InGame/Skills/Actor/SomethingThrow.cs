using System.Collections;
using UnityEngine;

public class SomethingThrow : MonoBehaviour, ISkillActor
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
        yield return null;

        Vector3 targetPos = Target.transform.position;
       
        //çUåÇîªíËê∂ê¨ÅB
        GameObject item = Instantiate(ac, transform);
        item.transform.position = transform.position;
        item.GetComponent<IThrowable>().ActThrow(targetPos, asbp.ap.bulletSpeed.value);

    }

    IEnumerator BackFrame()
    {

        yield return new WaitForSeconds(asbp.fp.backFrame.value);
    }
}

