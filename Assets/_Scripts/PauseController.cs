using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseGameobject;

    [SerializeField]
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseWindowFunc();
    }

    void PauseWindowFunc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGameobject.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void ClosePauseWindow()
    {
        pauseGameobject.SetActive(false);
        Player.GetComponent<PlayerController>().enabled = true;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1 2");
    }
}
