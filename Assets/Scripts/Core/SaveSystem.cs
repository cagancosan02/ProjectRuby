using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(PlayerData playerData)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string directoryPath = Application.persistentDataPath;
        string filePath = Path.Combine(directoryPath, "data.sav");

        FileStream stream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData Load()
    {
        string directoryPath = Application.persistentDataPath;
        string filePath = Path.Combine(directoryPath, "data.sav");

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
            return new PlayerData();
        }
    }
}
