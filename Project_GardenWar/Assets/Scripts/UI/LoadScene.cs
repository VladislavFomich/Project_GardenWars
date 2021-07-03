using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    public Button startButton;
    public int sceneNum;

    private void Start()
    {
        Button btnOne = startButton.GetComponent<Button>();
        btnOne.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
