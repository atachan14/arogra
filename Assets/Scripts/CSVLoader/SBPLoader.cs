using UnityEngine;

public class SBPLoader : MonoBehaviour
{
    [SerializeField] private TextAsset csvFile;

    void Start() // ← Awakeだとインポートとバッティングする可能性ある
    {
        if (csvFile != null)
        {
            SBPDB.LoadCSV(csvFile);
            Debug.Log("CSV読み込み完了");
        }
        else
        {
            Debug.LogError("CSVファイルが未設定だよ！");
        }
    }
}
