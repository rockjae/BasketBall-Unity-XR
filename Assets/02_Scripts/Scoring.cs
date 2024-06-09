using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int Points = 0;
    public TopTrigger triggerTop;
    public PracticeSounds PS;

    AudioSource audioSource;
    public AudioClip[] audioClips;
    public BasketBallManager basketBallManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(triggerTop.BallEnter == true)
        {
            if (basketBallManager.isLastTime)
            {
                Points += 3;
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
            else
            {
                Points += 2;
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            triggerTop.BallEnter = false;
            PS.PlayCheer();

        }
    }
}
