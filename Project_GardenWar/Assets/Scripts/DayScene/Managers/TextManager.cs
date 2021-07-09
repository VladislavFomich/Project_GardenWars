using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    public ActivateMenu activate;
   public int num;
    public Text[]  text;

    private void Update()

    {
        if (activate.numOfPlant != 0)
        {
            num = activate.numOfPlant-1;
            text[0].text = "Level " + PlantManager.Instance.plants[num].GetComponent<Plant>().level.ToString();
            text[1].text = "Damage " + PlantManager.Instance.plants[num].GetComponent<Plant>().damage.ToString();
            text[2].text = "Attack Speed " + PlantManager.Instance.plants[num].GetComponent<Plant>().bulletSpawnTime.ToString();
            text[3].text = "Bullet Speed " + PlantManager.Instance.plants[num].GetComponent<Plant>().bulletSpeed.ToString();
        }
     

    }

    //public void LoadData(SaveLoadManager.Save.PlantSaveData save)
    //{
    //    text[0].text = save.level.ToString();
    //    text[1].text = save.damage.ToString();
    //    text[2].text = save.bulletSpawnTime.ToString();
    //    text[0].text = save.bulletSpeed.ToString();
    //}

}
