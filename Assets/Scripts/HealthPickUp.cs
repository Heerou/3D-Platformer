using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthPickUp : MonoBehaviour
{
    [FormerlySerializedAs("HealAmount")] public int HealthAmount;
    public bool IsFullHealth;

    [SerializeField] private GameObject healthFX; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(healthFX, transform.position, transform.rotation);
            if (IsFullHealth)
            {
                HealthManager.HealthInstance.ResetHealth();
            }
            else
            {
                HealthManager.HealthInstance.AddHealth(HealthAmount);
            }
        }
    }
}
