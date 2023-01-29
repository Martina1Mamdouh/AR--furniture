using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Profile : MonoBehaviour
{
    #region Singleton:Profile
    public static Profile Instance;
     void Awake() {
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
    // Start is called before the first frame update

    public class products
    {
        public Sprite Image;
    }
    public List<products> ProductsList;
    [SerializeField] GameObject ProductUITemplate;
    [SerializeField] Transform ProductscrollView;
    GameObject g;
    int newSelectedIndex, PreviousSelectedIndex;
    [SerializeField] Color ActiveProductColor;
    [SerializeField] Color DefaultProductColor;
    [SerializeField] Image CurrentProduct;
    void Start()
    {
        GetAvailableProducts();
    }
    void GetAvailableProducts()
    {
    
        for (int i=0;i< ModelManager.Instance.models.Count; i++)
        {
            if (ModelManager.Instance.models[i].IsPurchase)
            {
                AddProducts(ModelManager.Instance.models[i].image);
            }
        }
    }
   
    public  void AddProducts(Sprite img )
    {
       
        if (ProductsList == null)
            ProductsList = new List<products>();
        products p = new products() {
            Image = img
        };
        
        ProductsList.Add(p);
        g = Instantiate(ProductUITemplate, ProductscrollView);
        g.transform.GetChild(0).GetComponent<Image>().sprite = p.Image;
    }

}
