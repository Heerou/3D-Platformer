using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    GameObject cpOff, cpOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks if the player has reached the checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.InstanceGM.SetSpawnPoint(transform.position);
            cpOff.SetActive(false);
            cpOn.SetActive(true);
        }
    }
}
