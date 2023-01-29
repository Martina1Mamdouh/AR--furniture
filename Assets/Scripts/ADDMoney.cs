using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADDMoney : MonoBehaviour
{
    #region Singletion:ADDMoney
    public static ADDMoney Instance;
    void Awake(){
        if(Instance ==null)
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

    [SerializeField] Text[] allMoneyUIText;
    public int Money;
  
    void Start()
    {
        UpdatesetAllMoneyUIText();
    }
    public void UseMoney(int amount)
    {
        Money += amount;
    }

    public void UpdatesetAllMoneyUIText()
    {
        for(int i=0; i < allMoneyUIText.Length;i++)
        {
            allMoneyUIText[i].text = Money.ToString();
        }
      
    }
   
}
