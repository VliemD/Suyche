using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ControlSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _secondsWaiting = 0.5f;

    private float _maxSoundVolume = 1f;
    private float _minSoundVolume = 0f;
    private float _recoveryRate = 0.1f;

    private Coroutine _coroutine;     

    public void IncreaseVolume()
    {
        StartChangeSoundVolume(_maxSoundVolume);
    }

    public void DecreaseVolume()
    {
        StartChangeSoundVolume(_minSoundVolume);
    }    

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void StartChangeSoundVolume(float necessitySoundVolume)
    {        
        StopRunningCoroutine();
        _coroutine = StartCoroutine(ChangeSoundVolume(necessitySoundVolume));
    }

    private void StopRunningCoroutine()
    {
        if ( _coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ChangeSoundVolume(float necessitySoundVolume)
    {
        while (_audio.volume != necessitySoundVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, necessitySoundVolume, _recoveryRate);

            yield return new WaitForSeconds(_secondsWaiting);
        }
    }
}
