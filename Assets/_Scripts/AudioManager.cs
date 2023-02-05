using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource _runningSound;
    [SerializeField] private AudioSource _jumpingSound;
    [SerializeField] private AudioSource _pickUpSound;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private PlayerAnimator _animator;
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
