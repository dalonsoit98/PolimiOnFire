using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Object[] texturesPlayer;
    private Renderer _rendererPlayer;

    public GameObject player;
    private int texId;
    public int totalECTS = 0;
    public Text ECTsText;
    // Start is called before the first frame update
    void Start()
    {
        ECTsText.text = totalECTS + " ECTs";
        //Path of the textures
        //_rendererPlayer = player.GetComponent<Renderer>();
        //string textPath = "Texture";
        //texturesPlayer = Resources.LoadAll(textPath, typeof(Texture2D));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToMainScene()
    {
        SceneManager.LoadScene("ManinMenu");
    }

    /*public void SetPlayerTexture()
    {
        _rendererPlayer.material.SetTexture("_MainTex", (Texture2D)texturesPlayer[1]);
    }*/

    public bool BuySkin(int price)
    {
        if (totalECTS >= price)
        {
            totalECTS -= price;
            ECTsText.text = totalECTS.ToString() + " ECTs";
            return true;
        }

        return false;
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("totalECTS", totalECTS);
    }
    void OnEnable()
    {
        totalECTS  =  PlayerPrefs.GetInt("totalECTS");
    }
}
