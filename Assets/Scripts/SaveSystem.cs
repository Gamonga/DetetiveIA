using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer (movimento movimento){

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(movimento);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveMusic (){

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/music.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData datamusica = new PlayerData();

        formatter.Serialize(stream, datamusica);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){

        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else{
            Debug.Log("error player");
            return null;
        }
    }
    public static PlayerData LoadMusica(){

        string path = Application.persistentDataPath + "/music.fun";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else{
            Debug.Log("error musica");
            return null;
        }
    }
}
