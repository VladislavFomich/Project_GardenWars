using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Button endButton;
    private void Start()
    {
        Button btnTwo = endButton.GetComponent<Button>();
        btnTwo.onClick.AddListener(CloseGame);
    }
    void CloseGame()
    {
        Application.Quit();
    }
}
