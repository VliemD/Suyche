using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(ControlSound))]
public class AlarmZone: MonoBehaviour
{
    private ControlSound _sound;

    private void Start()
    {
        _sound = GetComponent<ControlSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _sound.IncreaseVolume();        
    }

    private void OnTriggerExit(Collider other)
    {
        _sound.DecreaseVolume();        
    }    
}
