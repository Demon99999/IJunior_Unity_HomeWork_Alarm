using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAlarm : MonoBehaviour
{
    [SerializeField] private House _house;

    private AudioSource _audioSource;
    private Coroutine _activeCoroutine;
    private float _recoveryRate = 0.4f;
    private float _requiredValue;
    private float _minVolume=0f;
    private float _maxVolume=1f;

    private void OnEnable()
    {
        _house.Interacted += PlayAudio;
    }

    private void OnDisable()
    {
        _house.Interacted -= PlayAudio;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void PlayAudio(bool interact)
    {
        if (interact == true)
        {
            PlaySound();
        }
        else
        {
            StopSound();
        }
    }

    private void PlaySound()
    {
        _requiredValue = _maxVolume;
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private void StopSound()
    {
        _requiredValue = _minVolume;
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _requiredValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _requiredValue, _recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}
