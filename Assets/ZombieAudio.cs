using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] _zombieNearbySounds;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _audioDelay;
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
            StartCoroutine(ZombieNoises(_audioDelay));
        }
    }
    public IEnumerator ZombieNoises(float delay)
    {
        isPlaying = true;
        int randomChoice = Random.Range(0, _zombieNearbySounds.Length);
        _audioSource.PlayOneShot(_zombieNearbySounds[randomChoice]);
        yield return new WaitForSeconds(delay);
        isPlaying = false;
    }
}
