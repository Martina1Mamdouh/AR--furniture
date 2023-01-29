using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class DataHandler : MonoBehaviour
{
    private GameObject Furniture;
    [SerializeField] private ModelPrefab buttonManager;
    [SerializeField] private GameObject buttonContanier;
    [SerializeField] private List<Item> items;
    [SerializeField] private string label ;
    private int id = 0;
   
    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }
    private async void Start()
    {
        items = new List<Item>();
       await Get(label);
        //LoadItem();
        CreateButton(); 
    }
    //void LoadItem()
    //{
    //    var items_obk = Resources.LoadAll("items", typeof(Item));
    //    foreach(var item in items_obk)
    //    {
    //        items.Add(item as Item);
    //    }
    //}
    void CreateButton()
    {
        foreach(Item i in items)
        {
            ModelPrefab b = Instantiate(buttonManager, buttonContanier.transform);
            b.ItemId = id;
            b.Buttontexture = i.itemImage;
            id++;
        }
    }

    public void SetFurniture( int id)
    {
        Furniture = items[id].itemPrefab;
    }
    public GameObject getFurniture() => Furniture;
    public async Task Get(string label)
    {
        var Locations =await  Addressables.LoadResourceLocationsAsync(label).Task;
        foreach(var loc in Locations)
        {
            var obj = Addressables.LoadAssetAsync<Item>(loc).Task;
            items.Add(await obj);
        }
    }
}