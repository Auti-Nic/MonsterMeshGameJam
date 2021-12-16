using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeClock : MonoBehaviour
{
    Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        timeText = this.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        int minutes = (int)GameController.instance.timeLeftInMission / 60;
        int seconds = (int)(GameController.instance.timeLeftInMission - minutes * 60);
        string secondsString = seconds.ToString(); if (secondsString.Length == 1) secondsString = "0" + secondsString;
        timeText.text = minutes + ":" + secondsString;
    }
}
