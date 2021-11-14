using UnityEngine;
using UnityEngine.UI;

public class MaxScoreScript : MonoBehaviour
{
    public Text maxScoreText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MaxScoreUpdate(Text scoreText)
    {
        maxScoreText = scoreText;
    }
    void OnEnable()
    {
        maxScoreText.text  = PlayerPrefs.GetInt("maxScore").ToString();
    }
}
