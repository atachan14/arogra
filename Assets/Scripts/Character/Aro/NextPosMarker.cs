using UnityEngine;

public class NextPosMarker : MonoBehaviour
{
    NextPos np;
    Vector3 defaultScale;

    private void Start()
    {
        np = transform.root.GetComponentInChildren<NextPos>();
        defaultScale = transform.localScale;
    }
    void Update()
    {
        if(transform.position != np.Value)
        {
            transform.position = np.Value;
            
        }
        transform.localScale = defaultScale;
    }
}
