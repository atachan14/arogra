using UnityEngine;

public class NextPosMarker : MonoBehaviour
{
    NextPos np;

    private void Start()
    {
        np = transform.root.GetComponentInChildren<NextPos>();
    }
    void Update()
    {
        if(transform.position != np.Value)
        {
            transform.position = np.Value;
        }
    }
}
