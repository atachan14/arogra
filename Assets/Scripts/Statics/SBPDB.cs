using System.Collections.Generic;
using UnityEngine;

public static class SBPDB
{
    public static Dictionary<string, SkillParameter> skillBaseParameterDB = new();

    public static void LoadCSV(TextAsset csvFile)
    {

        string[] lines = csvFile.text.Split('\n');
        string[] headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            SkillParameter asbp = new SkillParameter();
            asbp.fp = new FrameParameter();
            asbp.rp = new RequireParameter();
            asbp.dp = new DamageParameter();
            asbp.ap = new ActParameter();
            asbp.bp = new BuffParameter();

            for (int j = 0; j < headers.Length; j++)
            {
                string header = headers[j];
                string value = values[j];

                // �� prefix�ŐU�蕪���đ��
                if (header.StartsWith("FP_"))
                    SetOptionalFloat(header.Substring(3), value, asbp.fp);
                else if (header.StartsWith("RP_"))
                    SetOptionalFloat(header.Substring(3), value, asbp.rp);
                else if (header.StartsWith("DP_"))
                    SetOptionalFloat(header.Substring(3), value, asbp.dp);
                else if (header.StartsWith("AP_"))
                    SetOptionalFloat(header.Substring(3), value, asbp.ap);
                else if (header.StartsWith("BP_"))
                    SetOptionalFloat(header.Substring(3), value, asbp.bp);
            }

            skillBaseParameterDB.Add(values[0], asbp);
        }
    }

    public static void SetOptionalFloat(string fieldName, string value, object target)
    {
        if (string.IsNullOrWhiteSpace(value)) return;

        if (float.TryParse(value, out float result))
        {
            var field = target.GetType().GetField(fieldName);
            if (field.FieldType == typeof(OptionalFloat))
            {
                var opt = new OptionalFloat();
                opt.value = result;
                opt.use = true;
                field.SetValue(target, opt);
            }
            else
            {
                Debug.LogWarning($"�t�B�[���h '{fieldName}' ��������Ȃ����A�^��float����Ȃ��� : {target.GetType().Name}");
            }
        }
        else
        {
            Debug.LogWarning($"'{value}' �� float �ɕϊ��ł��Ȃ�����");
        }
    }



    public static SkillParameter Get(string id)
    {
        return skillBaseParameterDB[id]; // �f�B�[�v�R�s�[����Ȃ炱����
    }
}
