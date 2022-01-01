using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
public class LogicaFullScreen : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update


    public TMP_Dropdown resolucionesDropDown;
    private Resolution[] resoluciones;
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
		RevisarResolucion();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
		
        for (int i = 0; i < resoluciones.Length; i++)
        {
			
			if (resoluciones[i].height!=1080){
 				if (resoluciones[i].height!=720) {
					if(resoluciones[i].height!=1440){
						if(resoluciones[i].height!=2160)continue;}}}

			


			
			


			

            string opcion = resoluciones[i].width + " x " + resoluciones[i].height + " @" + resoluciones[i].refreshRate;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height && resoluciones[i].refreshRate== Screen.currentResolution.refreshRate)
            {
                resolucionActual = i;

            }


			
		
            resolucionesDropDown.AddOptions(opciones);
            resolucionesDropDown.value = resolucionActual;
            resolucionesDropDown.RefreshShownValue();
        }
    }

    public void CambiarResolucion(int indiceResolucion)
        {
            Resolution resolucion = resoluciones[indiceResolucion];
            Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen, resolucion.refreshRate);
        }
        
        
    }