using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_update : MonoBehaviour
{
    public Scoring scoring;
    public TextMeshProUGUI ScoreUnits;
    public TextMeshProUGUI ScoreTens;
    private int Units, Tens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Units = scoring.Points % 10;
        Tens = scoring.Points / 10;
        ScoreUnits.text = Units.ToString();
        ScoreTens.text = Tens.ToString();
    }
}
