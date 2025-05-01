using UnityEngine;

public class CampManager : MonoBehaviour
{

    private void Start()
    {
        gameObject.name = transform.root.name + "_Camp";
    }

    public void LayerSetting(CampType campType)
    {
        gameObject.layer = LayerMask.NameToLayer(campType.ToString());
    }
}
