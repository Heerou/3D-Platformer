using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private int soundToPlay; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.InstanceGM.Respawn();
            AudioManager.AudioManagerInstance.PlaySoundFX(soundToPlay);
        }
    }
}
