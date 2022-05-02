using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoteca : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audios;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PLayAudio(int id, float vol) {
        audioSource.PlayOneShot(audios[id], vol);
    }
    public void PLayBook()
    {
        audioSource.PlayOneShot(audios[0], 0.9f);
    }
}
