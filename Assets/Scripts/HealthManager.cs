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

    public Sprite[] HealthImages;

    private void Awake()
    {
        HealthInstance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        ResetHealth();
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
        RefreshUIHealth();
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
        UIManager.UI_Instance.HealthImage.enabled = true;
        RefreshUIHealth();
    }

    public void AddHealth(int amountToHeal)
    {
        CurrentHealth += amountToHeal;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        RefreshUIHealth();
    }

    public void RefreshUIHealth()
    {
        UIManager.UI_Instance.HealthText.text = CurrentHealth.ToString();
        switch (CurrentHealth)
        {
            case 5:
                UIManager.UI_Instance.HealthImage.sprite = HealthImages[4];
                break;
            case 4:
                UIManager.UI_Instance.HealthImage.sprite = HealthImages[3];
                break;
            case 3:
                UIManager.UI_Instance.HealthImage.sprite = HealthImages[2];
                break;
            case 2:
                UIManager.UI_Instance.HealthImage.sprite = HealthImages[1];
                break;
            case 1:
                UIManager.UI_Instance.HealthImage.sprite = HealthImages[0];
                break;
            case 0:
                UIManager.UI_Instance.HealthImage.enabled = false;
                break;
        }
    }

    public void PlayerKilled()
    {
        CurrentHealth = 0;
        RefreshUIHealth();
    }
}