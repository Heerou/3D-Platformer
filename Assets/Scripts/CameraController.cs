using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public CinemachineBrain CmBrain;

    private void Awake()
    {
        Instance = this;
    }
}
