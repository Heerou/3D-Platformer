using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UI_Instance;
    
    public Image BlackScreen;
    [FormerlySerializedAs("FadeSpee")] public float FadeSpeed = 2f;
    public bool FadeToBlack, FadeFromBlack;
    public Text HealthText;
    public Image HealthImage;
    public Text CoinText;

    private void Awake()
    {
        UI_Instance = this;
    }

    private void Update()
    {
        if (FadeToBlack)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, 
                Mathf.MoveTowards(BlackScreen.color.a, 1f, FadeSpeed * Time.deltaTime));

            if (BlackScreen.color.a == 1)
            {
                FadeToBlack = false;
            }
        }
        if (FadeFromBlack)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, 
                Mathf.MoveTowards(BlackScreen.color.a, 0f, FadeSpeed * Time.deltaTime));
            
            if (BlackScreen.color.a == 0)
            {
                FadeFromBlack = false;
            }
        }
    }
}
