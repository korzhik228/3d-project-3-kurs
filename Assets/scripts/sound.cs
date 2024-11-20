using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _musicAudioSourse;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _jumpAudioSource;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _audioSource.Play();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _audioSource.Play();

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpAudioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            _audioMixer.SetFloat("Music", 0);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            _audioMixer.SetFloat("Music", -80);
        }
    }
}
