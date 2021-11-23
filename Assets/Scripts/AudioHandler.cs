using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _objectSound;
    
    private AudioSource _audioSource;
    private Player _player;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = GetComponent<Player>();
    }
    private void Start()
    {
        _player.OnClick += PlayObjectSound;
    }
    private void PlayObjectSound(int x) 
    {
        _audioSource.PlayOneShot(_objectSound);
    }
    private void OnDestroy()
    {
        _player.OnClick -= PlayObjectSound;
    }

}
