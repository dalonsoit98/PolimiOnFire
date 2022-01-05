using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
public class TimerScript : MonoBehaviour
{
    [Header ("Timer UI REFERENCES:")] 
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiText;

    private int Duration { get; set; }

    private int remainingDuration;

    public bool isPaused = false;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;

        Duration = remainingDuration = 0;
    }

    public TimerScript SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine((UpdateTimer()));
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            while (isPaused)
            {
                yield return null;
            }
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    public void End()
    {
        try
        {
            FindObjectOfType<PlayerMoveBuilding>().timerDeath();
        }
        catch
        {
            Debug.Log("Not in B1");
        }
        try
        {
            FindObjectOfType<PlayerMoveBuilding2>().timerDeath();
        }
        catch
        {
            Debug.Log("Not in B2");
        }
        try
        {
            FindObjectOfType<PlayerMoveBuilding3>().timerDeath();
        }
        catch
        {
            Debug.Log("Not in B3");
        }
        ResetTimer();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void PauseTimer()
    {
        isPaused = !isPaused;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
