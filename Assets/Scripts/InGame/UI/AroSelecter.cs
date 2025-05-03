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
            Debug.Log("AroSelecter�d�����͂��������イ�I");
            Destroy(gameObject); // �d�����������
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
