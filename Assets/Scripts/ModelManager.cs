using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
public class ModelManager : MonoBehaviour
{
    #region Singleton:ModelManager
    public static ModelManager Instance;
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
    [SerializeField]
    UIManager UIManager;
    [SerializeField]
    List<string> categories = new List<string>();
    [SerializeField]
      public List<Model> models = new List<Model>();
    [SerializeField]
    public Model currentModel;
   
    void Start()
    {
        UIManager.GenerateShop(categories, models);
    }

    public void ChoseModel(Model newModel)
    {
        currentModel = newModel;
    }
   
}

[System.Serializable]
public class Model
{
    public string name;
    public string category;
    public string description;
    public Sprite image;
    public GameObject prefab;
    public int price;
    public bool IsPurchase = false;
}
