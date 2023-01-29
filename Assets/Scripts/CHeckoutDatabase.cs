using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Proyecto26;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;

public class CHeckoutDatabase : MonoBehaviour
{
    DatabaseReference reference;
    public InputField username, address,phone;
    public Text price;
    public GameObject image;
    public string DataBase_Url = "";
    UsersData user = new UsersData();
    void Start()
    {
         
    }
    public void SaveData(int ItemIndex)
    {

        Debug.Log("called");
        user.username = username.text;
        user.Address = address.text;
        user.price = price.text;
        user.phone = phone.text;
       // user.img = Profile.Instance.ProductsList[ItemIndex].Image;
        RestClient.Post(DataBase_Url + "/" + user.username + ".json", user);
         Debug.Log("added successfully");
    }
    public void helloworld()
    {
        
         Debug.LogError("hello world"); 
          
    }

    void Update()
    {

    }
   
}
