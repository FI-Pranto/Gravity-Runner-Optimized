using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*public static class SaveSystem
{
    public static void SavePlayer(ScoreCoinCount scoreCoinCount)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fi";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(scoreCoinCount);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fi";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
*/


public static class SaveSystem
{
    public static void SavePlayer(ScoreCoinCount scoreCoinCount)
    {
        string path = Application.persistentDataPath + "/player.json";
        string json = JsonUtility.ToJson(new PlayerData(scoreCoinCount));

        File.WriteAllText(path, json);
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
