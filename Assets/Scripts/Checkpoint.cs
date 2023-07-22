using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject cpOff, cpOn;
    [SerializeField] private int soundToPlay; 


    //checks if the player has reached the checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.InstanceGM.SetSpawnPoint(transform.position);
            //Get all the checkpoints
            Checkpoint[] all_checkPoints = FindObjectsOfType<Checkpoint>();
            foreach (var check_point in all_checkPoints)
            {
                check_point.cpOff.SetActive(true);
                check_point.cpOn.SetActive(false);
            }
            cpOff.SetActive(false);
            cpOn.SetActive(true);
        }
        AudioManager.AudioManagerInstance.PlaySoundFX(soundToPlay);
    }
}