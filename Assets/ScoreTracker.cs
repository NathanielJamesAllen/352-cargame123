using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text reactionText;
    private float secondsOnScreen;
    private bool isOnscreen;
    private float stopAt = 3f;
    //private float[] startingPoint = 
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Current Score: " + score.ToString();
        reactionText.text = "";
    }
    private void Update() {
        if (isOnscreen) {
            secondsOnScreen += Time.deltaTime;
            if (secondsOnScreen >= stopAt){
                isOnscreen = false;
            }
        }
    }

    public void gainScore(int gain, string Text){
        score += gain;
        scoreText.text = "Current Score: " + score.ToString();
        reactionText.text = Text;
        secondsOnScreen = 0;
        isOnscreen = true;

    }

}