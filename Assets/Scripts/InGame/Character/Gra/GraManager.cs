using UnityEngine;

public class GraManager : MonoBehaviour
{
    void Start()
    {
        CampManager campManager = transform.parent.GetComponent<CampManager>();
        campManager.LayerSetting(LayerMask.GraHeart);
        SkillsManager skillManager = transform.root.GetComponentInChildren<SkillsManager>();
        skillManager.LayerSetting(LayerMask.GrasChecker);

    }
}

