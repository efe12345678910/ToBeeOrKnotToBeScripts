using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStartButtonSound : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayStartSound()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}
