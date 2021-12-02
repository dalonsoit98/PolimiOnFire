using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiningText : MonoBehaviour
{
    public Text winText;
    public bool isShown = false;

    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        winText.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
        {
            return;
        }

        transition += Time.deltaTime;
        winText.color = Color.Lerp(new Color(0, 0, 0, 0), Color.white, transition);
    }

    public void ToggleWinText()
    {
        gameObject.SetActive(true);
        isShown = true;
    }
}
