using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private Data data = new Data();
    public class Data
    {
        public List<Vector3> twoDList;
        public List<Vector3> threeDList;
    }

    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        if (!Directory.Exists(Application.dataPath + "/Save"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Save");
        }

        data.twoDList = GetComponent<GameManager>().twoDList;
        data.threeDList = GetComponent<GameManager>().threeDList;

        File.WriteAllText(Application.dataPath + "/Save" + "/SaveGame.sg", JsonUtility.ToJson(data));

        Debug.Log("Save");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.dataPath + "/Save" + "/SaveGame.sg"))
        {
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.dataPath + "/Save" + "/SaveGame.sg"));

            GetComponent<GameManager>().twoDList = data.twoDList;
            GetComponent<GameManager>().threeDList = data.threeDList;

            Debug.Log("Load");
        }
        else if (!File.Exists(Application.dataPath + "/Save" + "/SaveGame.sg"))
        {
            Debug.Log("No save");
        }
    }
}
