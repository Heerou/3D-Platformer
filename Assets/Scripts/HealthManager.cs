using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager HealthInstance;
    public int CurrentHealth, MaxHealth;
    public float InvincibleFramesLenght;
    private float invicibleCounter;

    private void Awake()
    {
        HealthInstance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;

            for (int i = 0; i < PlayerController.Instance.PlayerPieces.Length; i++)
            {
                if (Mathf.Floor(invicibleCounter * 5f) % 2 == 0)
                {
                    PlayerController.Instance.PlayerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.Instance.PlayerPieces[i].SetActive(false);
                }

                if (invicibleCounter <= 0)
                {
                    PlayerController.Instance.PlayerPieces[i].SetActive(true);
                }
            }
        }
    }

    public void Hurt()
    {
        CurrentHealth -= 1;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            GameManager.InstanceGM.Respawn();
        }
        else
        {
            PlayerController.Instance.Knockback();
            invicibleCounter = InvincibleFramesLenght;
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void AddHealth(int amountToHeal)
    {
        CurrentHealth += amountToHeal;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}