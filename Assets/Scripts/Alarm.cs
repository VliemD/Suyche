using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _necessitySoundVolume;
    private float _maxSoundVolume = 1f;
    private float _minSoundVolume = 0f;
    private float _recoveryRate = 0.1f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {       
        _audio.volume = Mathf.MoveTowards(_audio.volume, _necessitySoundVolume, _recoveryRate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {        
        TrySetMaxVolume(other, _maxSoundVolume);
    }

    private void OnTriggerExit(Collider other)
    {        
        TrySetMaxVolume(other, _minSoundVolume);
    }

    private void TrySetMaxVolume(Collider other, float maxValue)
    {
        if (other.GetComponent<ControlTester>())
            _necessitySoundVolume = maxValue;
    }
}
