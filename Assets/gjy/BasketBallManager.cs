using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketBallManager : MonoBehaviour
{
    public GameObject[] ball;
    Vector3[] ballPos;
    public GameObject ballWall;

    int Round;
    public GameObject RoundPanel;
    public TextMeshProUGUI RoundText;
    public Scoring scoring;
    AudioSource audioSource;
    public AudioSource endAudio;
    public AudioClip[] audioClip;

    public float Timer;
    public bool isLastTime;
    public bool isPlaying;
    bool isWait;

    public TextMeshProUGUI TimerTens;
    public TextMeshProUGUI TimerUnits;

    public TextMeshProUGUI RecodeTens;
    public TextMeshProUGUI RecodeUnits;

    private void Start()
    {
        int s = PlayerPrefs.GetInt("score",0);
        RecodeUnits.text = (s % 10).ToString();
        RecodeTens.text = (s / 10).ToString();

        audioSource = GetComponent<AudioSource>();

        ballPos = new Vector3[ball.Length];
        for(int i =0; i < ball.Length; i++)
        {
            ballPos[i] = ball[i].transform.position;
        }

        Round = 1;
        setRoundText();
    }

    public void StartGame()
    {
        RoundPanel.SetActive(true);
        setRoundText();

        audioSource.clip = audioClip[0];
        audioSource.Play();
        isPlaying = true;
        isWait = true;
        if(Round == 1)
        {
            scoring.Points = 0;
        }

        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].transform.position = ballPos[i];
        }

        ballWall.SetActive(true);

        StartCoroutine(waitStart());
    }

    IEnumerator waitStart()
    {
        yield return new WaitForSeconds(6f);

        RoundPanel.SetActive(false);
        Timer = 60;
        audioSource.clip = audioClip[1];
        audioSource.Play();
        ballWall.SetActive(false);
        isWait = false;
    }

    private void Update()
    {
        if (isPlaying && !isWait)
        {
            Timer -= Time.deltaTime;

            if (Timer < 15)
            {
                isLastTime = true;
            }
            else
            {
                isLastTime = false;
            }

            if(Timer < 0)
            {
                Timer = 0;
                roundCheck();
            }

            TimerUnits.text = ((int)Timer % 10).ToString();
            TimerTens.text = ((int)Timer / 10).ToString();
        }
    }

    void roundCheck()
    {
        endAudio.Play();

        if (Round == 1 && scoring.Points > 9)
        {
            Round = 2;
            StartGame();
        }
        else if(Round == 2 && scoring.Points > 29)
        {
            Round = 3;
            StartGame();
        }
        else
        {
            gameEnd();
        }
    }

    void gameEnd()
    {
        Round = 1;
        Timer = 0;
        isPlaying = false;
        isLastTime = false;
        scoring.Points = 0;
        audioSource.Stop();
        setRoundText();

        if(PlayerPrefs.GetInt("score") < scoring.Points)
        {
            PlayerPrefs.SetInt("score", scoring.Points);
            RecodeUnits.text = (scoring.Points % 10).ToString();
            RecodeTens.text = (scoring.Points / 10).ToString();
        }
    }

    void setRoundText()
    {
        if(Round == 1)
        {
            RoundText.text = "Round1\nGoal : 10";
        }
        else if (Round == 2)
        {
            RoundText.text = "Round2\nGoal : 30";
        }
        else if(Round == 3)
        {
            RoundText.text = "Round3\nGoal : All in";
        }
    }
}
