using UnityEngine;

public class SBPLoader : MonoBehaviour
{
    [SerializeField] private TextAsset csvFile;

    void Start() // �� Awake���ƃC���|�[�g�ƃo�b�e�B���O����\������
    {
        if (csvFile != null)
        {
            SBPDB.LoadCSV(csvFile);
            Debug.Log("CSV�ǂݍ��݊���");
        }
        else
        {
            Debug.LogError("CSV�t�@�C�������ݒ肾��I");
        }
    }
}
