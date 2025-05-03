
using UnityEngine;

public class AroManager : MonoBehaviour
{
    [SerializeField] InputReceiver receiver;
    [SerializeField] NextPosMarker marker;

    public InputReceiver Receiver { get => receiver; set => receiver = value; }
    public NextPosMarker Marker { get => marker; set => marker = value; }
  
    void Start()
    {
        CampManager campManager = transform.parent.GetComponent<CampManager>();
        campManager.LayerSetting(LayerMask.AroHeart);

        SkillsManager skillManager = transform.root.GetComponentInChildren<SkillsManager>();
        skillManager.LayerSetting(LayerMask.ArosChecker);

        AroSelecter.Instance.SelectAroButtonField(this);
    }
}
