using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthPickUp : MonoBehaviour
{
    public int HealAmount;
    public bool IsFullHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            if (IsFullHealth)
            {
                HealthManager.HealthInstance.ResetHealth();
            }
            else
            {
                HealthManager.HealthInstance.AddHealth(HealAmount);
            }
        }
    }
}
