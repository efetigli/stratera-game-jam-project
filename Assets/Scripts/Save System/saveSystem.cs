using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveMaterials(saveMaterials materialInfo){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/materialData";
        FileStream stream = new FileStream(path,FileMode.Create);
        materialData data = new materialData(materialInfo);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static materialData LoadMaterials(){
        string path = Application.persistentDataPath + "/materialData";
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
    public static void SavePlayer(savePlayer playerInfo){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/playerData";
        FileStream stream = new FileStream(path,FileMode.Create);
        playerData data = new playerData(playerInfo);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static playerData LoadPlayer(){
        string path = Application.persistentDataPath + "/playerData";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            playerData data =  formatter.Deserialize(stream) as playerData;
            stream.Close();
            return data;
        }
        else{
            return null;
        }
    }
    public static void SaveShip(saveShip shipInfo){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/shipData";
        FileStream stream = new FileStream(path,FileMode.Create);
        shipData data = new shipData(shipInfo);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static shipData LoadShip(){
        string path = Application.persistentDataPath + "/shipData";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            shipData data =  formatter.Deserialize(stream) as shipData;
            stream.Close();
            return data;
        }
        else{
            return null;
        }
    }
}
