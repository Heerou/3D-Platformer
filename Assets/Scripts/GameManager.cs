using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager InstanceGM;
    private Vector3 playerRespawnPos;

    private void Awake()
    {
        InstanceGM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        playerRespawnPos = PlayerController.Instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(Respawnco());
    }

    public IEnumerator Respawnco()
    {
        //Deactivates the player
        PlayerController.Instance.gameObject.SetActive(false);
        CameraController.Instance.CmBrain.enabled = false;
        
        //star coroutine
        yield return new WaitForSeconds(2f);
        
        //Set the player and camera position for the one that he had
        PlayerController.Instance.transform.position = playerRespawnPos;
        //Reactivates the player and the camera
        PlayerController.Instance.gameObject.SetActive(true);
        CameraController.Instance.CmBrain.enabled = true;
    }
}
