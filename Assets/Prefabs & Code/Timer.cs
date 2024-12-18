using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float currentTime;
    private float startingTime;
    public bool countDown;

    public bool hasLimit;
    public float timerLimit;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = currentTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!countDown){
            currentTime += Time.deltaTime;
            SetTimerText();
        }
        if (countDown){
            currentTime -= Time.deltaTime;
            SetTimerText();
        }

        if (hasLimit && (!countDown && currentTime >= timerLimit) || (countDown && currentTime <= timerLimit)){
            currentTime = timerLimit;
            timerText.text = "BOSS";
            TurnOff();
        }
    }

    public void TurnOff(){
      currentTime = 0;
      enabled = false;
    }

    public void TurnOn(){
      enabled = true;
    }

    private void SetTimerText(){
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

}
