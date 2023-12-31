using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _secondsWaiting = 0.5f;

    private float _maxSoundVolume = 1f;
    private float _minSoundVolume = 0f;
    private float _recoveryRate = 0.1f;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _waitForSeconds = new WaitForSeconds(_secondsWaiting);
    }

    public void IncreaseVolume()
    {
        StartChangeSoundVolume(_maxSoundVolume);
    }

    public void DecreaseVolume()
    {
        StartChangeSoundVolume(_minSoundVolume);
    }

    private void StartChangeSoundVolume(float necessitySoundVolume)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSoundVolume(necessitySoundVolume));
    }

    private IEnumerator ChangeSoundVolume(float necessitySoundVolume)
    {
        while (_audio.volume != necessitySoundVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, necessitySoundVolume, _recoveryRate);

            yield return _waitForSeconds;
        }
    }
}
