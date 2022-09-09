using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(materials materialInfo){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/MaterialData";
        FileStream stream = new FileStream(path,FileMode.Create);
        materialData data = new materialData(materialInfo);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static materialData LoadData(){
        string path = Application.persistentDataPath + "/MaterialData";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            materialData data =  formatter.Deserialize(stream) as materialData;
            stream.Close();
            return data;
        }
        else{
            return null;
        }
    }
}
