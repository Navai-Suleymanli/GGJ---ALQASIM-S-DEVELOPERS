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
    public void RunningSound() {
        _runningSound.Play(); 
    }
    public void JumpingSound()
    {
        _jumpingSound.Play();
    }
    public void PickUpSound()
    {
        _pickUpSound.Play();
    }
    public void DeathSound()
    {
        _deathSound.Play();
    }
}
