using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerDeathScript : MonoBehaviour
{
    public Text timerDeath;
    public bool isShown = false;

    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        timerDeath.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
        {
            return;
        }

        transition += Time.deltaTime;
        timerDeath.color = Color.Lerp(new Color(0, 0, 0, 0), Color.white, transition);
    }

    public void ToggleTimerDeath()
    {
        gameObject.SetActive(true);
        isShown = true;
    }
}
