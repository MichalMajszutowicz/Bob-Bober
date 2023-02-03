using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "00:00.00";
        timerGoing = false;
        BeginTimer();

        StartCoroutine(UpdateTimer());
    }

    public void BeginTimer(){
        timerGoing = true;
        elapsedTime = 0f;
    }

    public void EndTimer(){
        timerGoing = false;
    }

    private IEnumerator UpdateTimer(){
        while(timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingString = timePlaying.ToString("m':'ss'.'ff");
            timeCounter.text = timePlayingString;

            yield return null;
        }
    }
}
