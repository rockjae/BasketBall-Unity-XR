using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int Points = 0;
    public TopTrigger triggerTop;
    public AudioSource Score;
    public AudioSource Cheer;


    private void OnTriggerExit(Collider other)
    {
        if(triggerTop.BallEnter == true)
        {
            Points++;
            triggerTop.BallEnter = false;
            Score.Play();
            Cheer.Play();
        }
    }
}
