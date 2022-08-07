using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] AnimationCurve OnCollectAnimationCurve;
    [SerializeField] AudioClip collectSound;
    

    AudioSource audioSource;

    [SerializeField] bool playsAudio;

    protected virtual void Awake()
    {
        if (collectSound)
            playsAudio = true;

        if(playsAudio)
        {
            audioSource = GetComponent<AudioSource>();

        }
    }

    protected virtual void Collect(GameObject collector)
    {
        if (playsAudio)
        {
            audioSource.clip = collectSound;
            audioSource.Play();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect(collision.gameObject);
        Destroy(this.gameObject, .2f);
    }

}
