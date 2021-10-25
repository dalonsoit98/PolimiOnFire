using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int ECTs = 0;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 5;
    private int scoreToNextLevel = 10;

    public Text scoreText;
    public Text ECTsText;
    
    private bool isDead = false;
    private bool hasStarted = false;

    private void Start()
    {
        ECTsText.text = ECTs.ToString() + " ECTs";
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead || !hasStarted)
            return;
        
        if (score >= scoreToNextLevel)
            LevelUp ();
        
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int) score).ToString();
    }

    void LevelUp ()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        
        scoreToNextLevel *= 5;
        difficultyLevel++;

        GetComponent<PlayerMove>().SetSpeed (difficultyLevel);
    }

    public void HasStarted()
    {
        hasStarted = true;
    }

    public void OnDeath()
    {
        isDead = true;
    }

    public void ECTsUp()
    {
        ECTs += 1;
        ECTsText.text = ECTs.ToString() + " ECTs";
    }
}
