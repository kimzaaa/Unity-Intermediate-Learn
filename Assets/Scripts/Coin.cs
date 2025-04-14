using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    /*
    [SerializeField] private int price = 5;
    void PrintCurrentMoney(int currentMoney){
        Debug.Log($"Current money is {currentMoney}");        
    }

    private void OnEnable(){
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrentMoney); //suscribe
    }
    private void OnDisable(){
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrentMoney); //unsuscribe
    }

    public void Collect(){
        GameManager.Instance.Money = price; //refrenced the gameManager
        Destroy(gameObject);
    }
    */
    public void Collect(){
        Debug.Log("Coin collected!");
        Destroy(gameObject); //destroy the coin
    }
}
