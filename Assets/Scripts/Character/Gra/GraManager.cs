using UnityEngine;

public class GraManager : MonoBehaviour
{
    void Start()
    {
        CampManager campManager = transform.parent.GetComponent<CampManager>();
        campManager.LayerSetting(CampType.Gra);
        SkillsManager skillManager = transform.root.GetComponentInChildren<SkillsManager>();
        skillManager.LayerSetting(CampType.Gra);

    }
}

