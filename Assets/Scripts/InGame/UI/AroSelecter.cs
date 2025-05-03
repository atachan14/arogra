using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AroSelecter : MonoBehaviour
{
    public static AroSelecter Instance;
    [SerializeField] AroButtonField[] aroButtonFields = new AroButtonField[5];

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("AroSelecterèdï°ñ‚ëËÇÕÇ¡ÇπÇ¢ÇøÇ„Ç§ÅI");
            Destroy(gameObject); // èdï°ÇµÇΩÇÁè¡Ç∑
            return;
        }
        else
        {
            Debug.Log($"Instance:{Instance}");
        }
        Instance = this;
    }
    

    public void SelectAroButtonField(AroManager aro)
    {
        foreach (AroButtonField abf in aroButtonFields)
        {
            if (abf.AM == null)
            {
                abf.AroRegister(aro);
                break;
            }
        }
    }

   
}
