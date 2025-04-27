
using UnityEngine;

public class AroManager : MonoBehaviour
{
    void Start()
    {
        CampManager campManager = transform.parent.GetComponent<CampManager>();
        campManager.LayerSetting(CampType.Aro);
        SkillsManager skillManager = transform.root.GetComponentInChildren<SkillsManager>();
        skillManager.LayerSetting(CampType.Aro);

    }
}
