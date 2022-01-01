using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour
{
    public Image panelBrillo;

    private float brillo;
    // Start is called before the first frame update
    void Start()
    {
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, brillo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnEnable()
    {
        brillo = PlayerPrefs.GetFloat("brillo");
        
    }
}
