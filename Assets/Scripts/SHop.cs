using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SHop : MonoBehaviour
{

    #region Singletone:SHop
    public static SHop Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    [System.Serializable]
    public class ShopItem
    {
        public string name;
        public string category;
        public string description;
        public GameObject prefab;
        public Sprite Image;
        public int price;
        public bool IsPurchase = false;
    }
    public List<ShopItem> ShopItemList;
    public Model modell;
    [SerializeField] GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform SHopScrollView;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject Shop;
    Button buybtn;
    Button modelbtn;
 
    void Start()
    {
        int len = ShopItemList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, SHopScrollView);
            modelbtn = g.transform.GetChild(0).GetComponent<Button>();
            g.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemList[i].price.ToString();
            modelbtn.image.sprite = ShopItemList[i].Image;
            buybtn = g.transform.GetChild(2).GetComponent<Button>();

            if (ShopItemList[i].Image)
            {
              // UIManager.UseModel();
            }
            modelbtn.AddEventListener(i, OnARclicked);
            if (ShopItemList[i].IsPurchase)
            {
                DisableBuyButton();
            }
            buybtn.AddEventListener(i, OnSHopItemBtnClicked);
        }
    }
   
    void OnSHopItemBtnClicked(int ItemIndex)
    {
        ADDMoney.Instance.UseMoney(ShopItemList[ItemIndex].price);
        ShopItemList[ItemIndex].IsPurchase = true;

        buybtn = SHopScrollView.GetChild(ItemIndex).GetChild(2).GetComponent<Button>();
        DisableBuyButton();

        ADDMoney.Instance.UpdatesetAllMoneyUIText();
        Profile.Instance.AddProducts(ShopItemList[ItemIndex].Image);

    }

    void DisableBuyButton()
    {
        buybtn.interactable = false;
        buybtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

    
    void OnARclicked(int ItemIndex )
    {
        modelbtn = SHopScrollView.GetChild(ItemIndex).GetChild(1).GetComponent<Button>();
       
        ADDMoney.Instance.UpdatesetAllMoneyUIText();

        modelbtn = SHopScrollView.GetChild(0).GetComponent<Button>();
        MainMenu.SetActive(true);
        Shop.SetActive(true);
        MainPanel.SetActive(false);
       
    }
    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
}
