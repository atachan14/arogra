
using UnityEngine;

public class AroManager : MonoBehaviour
{
    void Start()
    {
        CampManager campManager = transform.parent.GetComponent<CampManager>();
        campManager.LayerSetting(LayerMask.AroHeart);

        SkillsManager skillManager = transform.root.GetComponentInChildren<SkillsManager>();
        skillManager.LayerSetting(LayerMask.ArosChecker);

    }
}
