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
    private void RunningSound() {
        _runningSound.Play(); 
    }
    private void JumpingSound()
    {
        _jumpingSound.Play();
    }
    private void PickUpSound()
    {
        _pickUpSound.Play();
    }
    private void DeathSound()
    {
        _deathSound.Play();
    }
}
