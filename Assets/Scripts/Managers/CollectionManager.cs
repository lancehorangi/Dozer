using UnityEngine;
using System.Collections;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager instance;
    public int coins = 50;
    public int prizes = 2;
    public int shakes = 3;
    public int walls = 2;
    /**Таймер добавления монеты, сек*/
    public float additionalCoinTimer = 20f;
    public enum CollectionType
    {
        COIN,
        PRIZE,
        SHAKE,
        WALL
    }
    //получить монеты
    public delegate void ChangeCollectionHandler(CollectionType type, Action.Type actionType, int count, int changeValue);
    public static event ChangeCollectionHandler OnChange;
    
    //PRIVATE
    private float coinTimer = 0f;

	// Use this for initialization
    void Start()
    {
        coinTimer = additionalCoinTimer;
        try
        {
            OnChange(CollectionType.COIN, Action.Type.VALUE, coins, 0);
            OnChange(CollectionType.PRIZE, Action.Type.VALUE, prizes, 0);
        }
        catch { };
	}

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Collector.OnCollect += OnCollect;
    }
    void OnCollect(CollectionManager.CollectionType type)
    {
        if(type == CollectionType.COIN)
            ChangeCoins(Action.Type.ADD, 1);
        else if (type == CollectionType.PRIZE) 
            ChangePrizes(Action.Type.ADD, 1);
    }
    // Update is called once per frame
    private void Update()
    {
        //Таймер добавления монеты
        if (coinTimer <= 0)
        {
            coinTimer = additionalCoinTimer;
            ChangeCoins(Action.Type.ADD, 1);
        }
        else
            coinTimer -= Time.deltaTime;
    }

    public void ChangeCoins(Action.Type actionType, int changeValue)
    {
        Change(ref coins, actionType, changeValue);
        OnChange(CollectionType.COIN, actionType, coins, changeValue);
    }
    public void ChangePrizes(Action.Type actionType, int changeValue)
    {
        Change(ref prizes, actionType, changeValue);
        OnChange(CollectionType.PRIZE, actionType, prizes, changeValue);
    }

    public void ChangeShakes(Action.Type actionType, int changeValue)
    {
        Change(ref shakes, actionType, changeValue);
        OnChange(CollectionType.SHAKE, actionType, shakes, changeValue);
    }
    public void ChangeWalls(Action.Type actionType, int changeValue)
    {
        Change(ref walls, actionType, changeValue);
        OnChange(CollectionType.WALL, actionType, walls, changeValue);
    }

    private void Change(ref int collection, Action.Type actionType, int changeValue)
    {
        switch (actionType)
        {
            case Action.Type.ADD:
                collection += changeValue;
                break;
            case Action.Type.SPEND:
                collection -= changeValue;
                break;
            case Action.Type.VALUE:
                collection = changeValue;
                break;
        }
    }
    //Получить значение по типу
    public int GetValue(CollectionManager.CollectionType type)
    {
        switch (type)
        {
            case CollectionType.COIN: return coins;
            case CollectionType.PRIZE: return prizes;
            case CollectionType.SHAKE: return shakes;
            case CollectionType.WALL: return walls;
            default: return 0;
        }
    }
}

public class Action
{
    public enum Type
    {
        ADD,    //добавить монеты
        SPEND,  //потратить монеты
        VALUE   //задать количество монет
    }
}
