using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    public bool countdownDone = false;
    public GameObject countdownImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownDone)
        {
            countdownImage.SetActive(false);
        }
        else
        {
            countdownImage.SetActive(true);
        }
    }

    public void CountdownFinished(bool x)
    {
       countdownDone = x;
    }
}
