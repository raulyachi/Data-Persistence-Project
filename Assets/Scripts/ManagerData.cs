using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ManagerData : MonoBehaviour
{
    // Start is called before the first frame update

    public static ManagerData Instance;
    public InputField NameInput;
    public string NombreGamer; // new variable declared
    public int Points; // new variable declared
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPoints();
    }

    [System.Serializable]
    class SaveData
    {
        public string NombreGamer;
        public int Points;
    }

    public void SavePoints()
    {
        SaveData data = new SaveData();
        data.NombreGamer = NombreGamer;
        data.Points = Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPoints()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            NombreGamer = data.NombreGamer;
            Points = data.Points;
        }
    }
}
