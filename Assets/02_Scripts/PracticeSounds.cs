using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSounds : MonoBehaviour
{
    public AudioSource Bounce;
    public AudioSource Cheer;
    public void PlayBounce()
    {
        Bounce.Play();
    }
    
    public void PlayCheer()
    {
        Cheer.Play();
    }


}
