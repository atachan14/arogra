using UnityEngine;

public class ToDirThrowable : MonoBehaviour, IThrowable
{
    Vector3 dir;
    float speed;
    public void ActThrow(Vector3 targetPos, float speed)
    {
        dir = targetPos - transform.position;
        this.speed = speed;
        Debug.Log("tobimasu");
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        Debug.Log("tonderu");
        //FlyingOption();
    }

    protected virtual void FlyingOption()
    {

    }
}
