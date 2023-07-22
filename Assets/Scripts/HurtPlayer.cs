using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] private int soundToPlay; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealthManager.HealthInstance.Hurt();
            AudioManager.AudioManagerInstance.PlaySoundFX(soundToPlay);
        }
    }
}
