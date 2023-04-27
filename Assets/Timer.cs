using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerString;
    public TMP_Text postTimerString;
    float timer = 0f;
    bool flashingTimer;
    int flashCount; //What a feeling
    float microTimer = 0f;
    [SerializeField] Flasher flasher;
    [SerializeField] int maxFlashes;
    [SerializeField] float flashDuration;

    // Start is called before the first frame update
    void Start()
    {
        timerString.text = timer.ToString();
        postTimerString.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerString.text = timer.ToString("0.##");
        if(flashingTimer && microTimer > flashDuration){
            microTimer = 0;
            flasher.flash();
            flashCount++;
            if(flashCount > maxFlashes){
                flashingTimer = false;
                postTimerString.text = "";
            }
        }
        else{
            microTimer += Time.deltaTime;
        }
    }
    public void resetTimer(){
        Debug.Log("post timer string");
        postTimerString.text = "Last delivery time: " + timer.ToString("00.##");
        timer = 0;
        flashingTimer = true;
        flashCount = 0;
        microTimer = 0f;
    }
}
