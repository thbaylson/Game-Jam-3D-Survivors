using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] _zombieNearbySounds;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _audioDelay;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(ZombieNoisesLoop());
    }

    private IEnumerator ZombieNoisesLoop()
    {
        float offsetter = Random.Range(0, 5);
        yield return new WaitForSeconds(offsetter);
        while (true)
        {
            int randomChoice = Random.Range(0, _zombieNearbySounds.Length);
            _audioSource.PlayOneShot(_zombieNearbySounds[randomChoice]);
            yield return new WaitForSeconds(_zombieNearbySounds[randomChoice].length);
            yield return new WaitForSeconds(_audioDelay);
        }
    }
}
