using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _bulletSound;
    [SerializeField] private AudioClip[] _runSounds;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _bulletDelay;
    [SerializeField] private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayerBulletSound(_bulletDelay));
        }
    }
    public IEnumerator PlayerBulletSound(float delay)
    {
        isPlaying = true;
        _audioSource.PlayOneShot(_bulletSound);
        yield return new WaitForSeconds(delay);
        isPlaying = false;
    }
}
