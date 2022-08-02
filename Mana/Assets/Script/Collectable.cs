using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] AnimationCurve OnCollectAnimationCurve;
    [SerializeField] AudioClip collectSound;
    

    AudioSource audioSource;

    [SerializeField] bool playsAudio;

    private void Awake()
    {
        if (collectSound)
            playsAudio = true;

        if(playsAudio)
        {
            audioSource = GetComponent<AudioSource>();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playsAudio)
        {
            audioSource.clip = collectSound;
            audioSource.Play();
        }

        Destroy(this.gameObject,.2f);
    }

}
