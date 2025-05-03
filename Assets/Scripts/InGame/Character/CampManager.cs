using UnityEngine;

public class CampManager : MonoBehaviour
{

    private void Start()
    {
        gameObject.name = transform.root.name + "_Camp";
    }

    public void LayerSetting(LayerMask campType)
    {
        gameObject.layer = UnityEngine.LayerMask.NameToLayer(campType.ToString());
    }
}
