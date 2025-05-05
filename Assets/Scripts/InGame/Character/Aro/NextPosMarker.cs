using UnityEngine;

public class NextPosMarker : MonoBehaviour
{
    NextPos np;

    private void Start()
    {
        np = transform.root.GetComponentInChildren<NextPos>();
        //SetupColor();
    }

    void SetupColor()
    {
        Color npmColor = transform.root.GetComponentInChildren<BodySprite>().GetComponent<SpriteRenderer>().color;
        npmColor.a = 0.2f;
        GetComponent<SpriteRenderer>().color = npmColor;
    }

    void Update()
    {
        if(transform.position != np.Value)
        {
            transform.position = np.Value;
            
        }
    }
}
