using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    //public delegate int MoneyChanged();
    //public static evet MoneyChange OnMoneyChanged;
    
    public UnityEvent<int> OnMoneyChanged;
    public UnityEvent<int> OnAmountChanged;

    private int _money;
    private int _CollectableAmount;

    public int Money{
        get => _money;
        /*get{return _money}*/
        set{
            //Money = 123
            //value = 123
            _money += value; //add value to money
            //_money += value;
            OnMoneyChanged.Invoke(_money); //call the event
        }
    }

    public int Amount{
        get => _CollectableAmount;
        set{
            _CollectableAmount += value; //add value to money
            //_money += value;
            OnAmountChanged.Invoke(_CollectableAmount); //call the event
        }
    }
}
