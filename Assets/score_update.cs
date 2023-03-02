using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_update : MonoBehaviour
{
    public Scoring scoring;
    public TextMeshProUGUI Scoretm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scoretm.text = scoring.Points.ToString();
    }
}
