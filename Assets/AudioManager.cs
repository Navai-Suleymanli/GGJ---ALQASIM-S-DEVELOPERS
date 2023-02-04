using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        Move();
    }

    private void Move() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
            Debug.Log("fds;fksd");
            audioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
            Debug.Log("stop");
            audioSource.Stop();
        }
    }
}
