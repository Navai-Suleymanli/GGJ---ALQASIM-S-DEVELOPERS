using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void CloseGame()
    {
        
        Application.Quit();

    }
    public void StartLevel()
    {
        SceneManager.LoadScene("Level1 1");
    }
}
