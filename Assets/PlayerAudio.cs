using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] _bulletAbilitySound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public int _abilityLevel =0;
    

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayAbilitySounds();
    }


    public void PlayAbilitySounds()
    {
        _audioSource.clip = _bulletAbilitySound[_abilityLevel];
        _audioSource.Play();
    }
}
