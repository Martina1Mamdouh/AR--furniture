using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelPrefab : MonoBehaviour
{
    private int _ItemId;
   [SerializeField] private RawImage buttonImage;
    private Sprite _buttontexture;
    public Sprite Buttontexture
    {
        set
        {
            _buttontexture = value;
            buttonImage.texture = _buttontexture.texture;
        }
    }
    public int ItemId
    {
        set
        {
            _ItemId = value;
        }
    }
    [SerializeField] Text price;
    UIManager UIManager;
    [SerializeField]
    Button button;
    public Model model;
    float x;
    [SerializeField] Button buybtn;

    [SerializeField]
    public List<Model> models ;
    void Awake()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        button.onClick.AddListener(() => UIManager.OpenModelWindow(model));
    }
     void Start()
     {
        models = ModelManager.Instance.models;
        int len = models.Count;
        x = Random.Range(1000, 2000);
        price.text = x.ToString() + " L.E.";
        for (int i=0;i<len;i++)
        {
            if (models[i].IsPurchase)
            {
                //DisableBuyButton();
            }
        }
    }

    public void onclick()
    {
        Debug.Log(x);
        Debug.Log(models.Count);
        ADDMoney.Instance.UseMoney((int)x);
        model.IsPurchase = true;
        ADDMoney.Instance.UpdatesetAllMoneyUIText();
        Profile.Instance.AddProducts(model.image);
    }

    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(_ItemId);
    }
}

