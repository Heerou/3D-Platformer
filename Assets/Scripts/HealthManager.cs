using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager HealthInstance;
    public int CurrentHealth, MaxHealth;

    private void Awake()
    {
        HealthInstance = this;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Hurt()
    {
        CurrentHealth -= 1;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            GameManager.InstanceGM.Respawn();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
