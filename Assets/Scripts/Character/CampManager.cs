using UnityEngine;

public class CampManager : MonoBehaviour
{

    public void LayerSetting(CampType campType)
    {
        gameObject.layer = LayerMask.NameToLayer(campType.ToString());
    }
}
