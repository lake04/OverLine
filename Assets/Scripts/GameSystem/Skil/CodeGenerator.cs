using System.IO;
using UnityEngine;

public class CodeGenerator : MonoBehaviour
{
    public string jsonFilePath = "Assets/Resources/SkillData.json";  
    public string classFilePath = "Assets/Scripts/SkillData.cs";    

    void Start()
    {
        GenerateCSharpClass();
    }

    void GenerateCSharpClass()
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            skillInfoData skillData = JsonUtility.FromJson<skillInfoData>(jsonContent);
            string classCode = CreateClassCode(skillData);
            WriteClassToFile(classCode);
        }
        else
        {
            Debug.LogError("颇老绝澜.");
        }
    }

    string CreateClassCode(skillInfoData skillData)
    {
        string classCode = "using System;\n\n";
        classCode += "public class SkillData\n{\n";

        foreach (var skill in skillData.skills)
        {
            classCode += $"    public string {skill.skillName};\n";
        }

        classCode += "}\n";
        return classCode;
    }

    void WriteClassToFile(string classCode)
    {
        File.WriteAllText(classFilePath, classCode);
        Debug.Log("C#颇老 积己");
    }
}
