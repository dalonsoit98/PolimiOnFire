
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class ShopMenu : MonoBehaviour
{
    [System.Serializable] class shopItem
    {
        public Texture2D texturesPlayer;
        public int Price;
        public bool IsPurchased = false;
    }

    [SerializeField] private List<shopItem> ShopItemsList;
    
    private GameObject ItemTemplate;
    private GameObject g;
    private Renderer _rendererPlayer;

    [SerializeField] Transform ShopScrollView;

    private Button buyButton;
    private Button useButton;
    // Coins Menu

    public int textureId = 0;
    // Start is called before the first frame update
    private void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        int len = ShopItemsList.Count;
        
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            _rendererPlayer = g.GetComponent<Renderer>();
            g.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().material.SetTexture("_MainTex", ShopItemsList[i].texturesPlayer);
            g.transform.GetChild(2).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            buyButton = g.transform.GetChild(3).GetComponent<Button>();
            useButton = g.transform.GetChild(4).GetComponent<Button>();
            buyButton.interactable = !ShopItemsList[i].IsPurchased;
            useButton.interactable = ShopItemsList[i].IsPurchased;
            if (ShopItemsList[i].IsPurchased)
            { 
                buyButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
            }
            if (i == textureId)
            {
                useButton.interactable = false;
            }
            buyButton.AddEventListener(i,OnShopItemButtonClicked);
            useButton.AddEventListener(i,OnUseItemButtonClicked);
        }
        Destroy(ItemTemplate);
    }

    void OnShopItemButtonClicked(int itemIndex)
    {
        if (FindObjectOfType<CharacterMenu>().BuySkin(ShopItemsList[itemIndex].Price))
        {
            ShopItemsList[itemIndex].IsPurchased = true;

            buyButton = ShopScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>();
            buyButton.interactable = false;
            useButton = ShopScrollView.GetChild(itemIndex).GetChild(4).GetComponent<Button>();
            useButton.interactable = true;
            buyButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
        }
        else
        {
            return;
        }
    }

    void OnUseItemButtonClicked(int itemIndex)
    {
        if (textureId != itemIndex)
        {
            textureId = itemIndex;
            useButton = ShopScrollView.GetChild(itemIndex).GetChild(4).GetComponent<Button>();
            useButton.interactable = false;
            for (int i = 0; i < ShopItemsList.Count;i++)
            {
                useButton =ShopScrollView.GetChild(i).GetChild(4).GetComponent<Button>();
                if ((itemIndex!=i) && (ShopItemsList[i].IsPurchased))
                useButton.interactable = true;
            }
        }
        else
        {
            return;
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("textureId",textureId);
        
        for( int i = 0 ;i < ShopItemsList.Count; i++)
        {
            if (ShopItemsList[i].IsPurchased)
            {
                PlayerPrefs.SetInt("IsPurchased" + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt("IsPurchased" + i, 0);  
            }
        }
    }
    void OnEnable()
    {
        textureId = PlayerPrefs.GetInt("textureId");
        
        for (int i = 0; i < ShopItemsList.Count; i++)
        {
            if (PlayerPrefs.GetInt("IsPurchased" + i) == 1)
            {
                ShopItemsList[i].IsPurchased = true;
            }
            else
            {  
                ShopItemsList[i].IsPurchased = false;
            }
        }
    }
}
