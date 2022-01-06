using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iam_InTheWay : MonoBehaviour
{
    [SerializeField] private GameObject solidBody;
    [SerializeField] private GameObject transparentBody;
    // Start is called before the first frame update
    void Awake()
    {
        ShowSolid();
    }
    
    public void ShowTransparent()
    {
        solidBody.SetActive(false);
        transparentBody.SetActive(true);
    }

    public void ShowSolid()
    {
        solidBody.SetActive(true);
        transparentBody.SetActive(false);
    }
}
