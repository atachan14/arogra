using UnityEngine;

public class InputReceiver : MonoBehaviour
{
    NextPos np;
    NowState state;
    Camera mainCam;

    private void Start()
    {
        np = transform.root.GetComponentInChildren<NextPos>();
        state = transform.root.GetComponentInChildren<NowState>();
        mainCam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) ClickMove();
        if (Input.GetKey(KeyCode.Space)) CameraMove();
    }

    void ClickMove()
    {
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos.z = np.Value.z;
        np.Value = clickPos;

        if (state.SkillState == SSC.Free
            || state.SkillState == SSC.Walk)
        {
            state.SkillState = SSC.Walk;
        }
        else
        {
            state.SkillState = SSC.Run;
        }
    }

    void CameraMove()
    {
        float z = mainCam.transform.position.z;
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, z);

    }
}
