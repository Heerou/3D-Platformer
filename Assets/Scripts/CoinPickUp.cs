using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int CoinValue;
    [SerializeField] GameObject pickupFX;
    [SerializeField] int soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.InstanceGM.AddCoins(CoinValue);
            Destroy(gameObject);
            Instantiate(pickupFX, transform.position, transform.rotation);
            AudioManager.AudioManagerInstance.PlaySoundFX(soundToPlay);
        }
    }
}
