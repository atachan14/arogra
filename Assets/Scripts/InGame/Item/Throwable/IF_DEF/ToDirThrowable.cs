using UnityEngine;

public class ToDirThrowable : MonoBehaviour, IThrowable
{
    Vector3 dir;
    float speed;
    public void ActThrow(Vector3 dir,float speed)
    {
        this.dir = dir;
        this.speed = speed;
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        FlyingOption();
    }

    protected virtual void FlyingOption()
    {

    }
}
