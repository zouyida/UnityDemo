using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
public class ReadEDList
{
    static ReadEDList()
    {
        string filePath = Application.dataPath + "/Editor/EnemyDataList.xlsx";
        string assetName = "EnemyDataList";
        FileInfo fileInfo = new FileInfo(filePath);
        EnemyDataList enemyDataList = (EnemyDataList)ScriptableObject.CreateInstance(typeof(EnemyDataList));
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Enemy"];
            for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++)
            {
                EnemyData enemyData = new EnemyData();
                Type type = typeof(EnemyData);
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {   //Color color = (Color)Enum.Parse(typeof(Color), red, true);
                    FieldInfo variable = type.GetField(worksheet.GetValue(2, j).ToString());
                    string tableValue = worksheet.GetValue(i, j).ToString();
                    variable.SetValue(enemyData, Convert.ChangeType(tableValue, variable.FieldType));
                }
                enemyDataList.enemyDataList.Add(enemyData);
            }
        }
        AssetDatabase.CreateAsset(enemyDataList, "Assets/Resources/" + assetName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
