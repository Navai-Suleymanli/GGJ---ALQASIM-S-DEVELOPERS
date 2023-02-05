using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource _runningSound;
    [SerializeField] private AudioSource _jumpingSound;
    [SerializeField] private AudioSource _backSound;
    [SerializeField] private AudioSource _ambianceSond;
    [SerializeField] private AudioSource _pickUpSound;
    [SerializeField] private AudioSource _deathSound;
    
    

    private void Start()
    {
        _backSound.Play();
        _ambianceSond.Play();
       
    }
    private void Update()
    {
      
     
        Move();
    }

    private void Move() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
           
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
           
        }
    }
}
