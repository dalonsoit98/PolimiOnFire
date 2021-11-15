using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int ECTs = 0;
    public int maxScore;
    private int totalECTS;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 5;
    private int scoreToNextLevel = 10;

    public Text scoreText;
    public Text ECTsText;

    private bool isDead = false;
    private bool hasStarted = false;

    public DeathMenuScript deathMenu;
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
        totalECTS += ECTs;
        if (score > maxScore)
        {
            maxScore = ((int) score);
          //  FindObjectOfType<MaxScoreScript>().maxScoreText.text = maxScore.ToString();
        }
        deathMenu.ToogleEndMenu(maxScore);
    }

    public void ECTsUp()
    {
        ECTs += 1;
        ECTsText.text = ECTs.ToString() + " ECTs";
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("maxScore", maxScore);
        PlayerPrefs.SetInt("totalECTS", totalECTS);
    }
    void OnEnable()
    {
        maxScore = PlayerPrefs.GetInt("maxScore");
        totalECTS  =  PlayerPrefs.GetInt("totalECTS");
    }
}
