using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager InstanceGM;
    private Vector3 playerRespawnPos;
    
    [SerializeField] private GameObject playerDeathFX;

    public int CurrentCoins;

    private void Awake()
    {
        InstanceGM = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerRespawnPos = PlayerController.Instance.transform.position;

        UIManager.UI_Instance.FadeFromBlack = true;
        AddCoins(0);
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
        HealthManager.HealthInstance.PlayerKilled();
    }

    public IEnumerator RespawnCo()
    {
        //Deactivates the player
        PlayerController.Instance.gameObject.SetActive(false);
        CameraController.Instance.CmBrain.enabled = false;
        UIManager.UI_Instance.FadeToBlack = true;

        Instantiate(playerDeathFX, PlayerController.Instance.transform.position + new Vector3(0f,1f,0f), 
            PlayerController.Instance.transform.rotation);
        
        yield return new WaitForSeconds(3f);
        HealthManager.HealthInstance.ResetHealth();
        UIManager.UI_Instance.FadeFromBlack = true;

        //Set the player and camera position for the one that he had
        PlayerController.Instance.transform.position = playerRespawnPos;
        //Reactivates the player and the camera
        PlayerController.Instance.gameObject.SetActive(true);
        CameraController.Instance.CmBrain.enabled = true;
    }

    //Sets a new position for the spawn of the player
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        playerRespawnPos = newSpawnPoint;
        Debug.Log("Spawn point set");
    }

    public void AddCoins(int coinToAdd)
    {
        CurrentCoins += coinToAdd;
        UIManager.UI_Instance.CoinText.text = "" + "x" + CurrentCoins;
    }
}