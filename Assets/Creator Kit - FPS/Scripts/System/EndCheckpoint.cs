﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    public string endGameSound;

    void OnTriggerEnter(Collider other)
    {

        FMODUnity.RuntimeManager.PlayOneShot(endGameSound, GetComponent<Transform>().position);

        if (other.GetComponent<Controller>() == null)
            return;
        
        
        GameSystem.Instance.StopTimer();
        GameSystem.Instance.FinishRun();
        Destroy(gameObject);
    }
}
