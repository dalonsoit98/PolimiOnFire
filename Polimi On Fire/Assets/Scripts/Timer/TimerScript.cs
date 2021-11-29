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
        FindObjectOfType<PlayerMoveBuilding>().timerDeath();
        ResetTimer();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
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
