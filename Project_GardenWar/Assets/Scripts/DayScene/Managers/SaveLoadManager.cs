using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    string filePath;
    public List<GameObject> planstSave = new List<GameObject>();
    public GameObject textManager;
    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.SavePlant(planstSave);
        bf.Serialize(fs, save);
        fs.Close();
    }
    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        //int i = 0;
        //foreach (var item in save.plantsData)
        //{
        //    planstSave[i].GetComponent<Plant>().LoadData(item);
        //    i++;
        //}
    }

    [System.Serializable]
    public class Save
    {
        [System.Serializable]
        public struct PlantSaveData
        {
            public int numOnGround;
            public int level;
            public float bulletSpawnTime;
            public int damage;
            public float bulletSpeed;
        }
        public List<PlantSaveData> plantsData = new List<PlantSaveData>();
        public void SavePlant(List<GameObject> plants)
        {
            foreach (var item in plants)
            {
                Plant plantScript = item.GetComponent<Plant>();
                PlantSaveData saveData;
                saveData.numOnGround = plantScript.numOnGround;
                saveData.level = plantScript.level;
                saveData.bulletSpawnTime = plantScript.bulletSpawnTime;
                saveData.damage = plantScript.damage;
                saveData.bulletSpeed = plantScript.bulletSpeed;
                plantsData.Add(new PlantSaveData());
            }
        }
    }
}
