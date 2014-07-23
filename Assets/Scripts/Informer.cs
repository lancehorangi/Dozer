using UnityEngine;
using System.Collections.Generic;

public class Informer : MonoBehaviour {

    public static Informer instance = null;
    public enum InfoType
    {
        COIN,
        DOUBLE,
        TRIPPLE,
        COIN_ATTACK,
        PRIZE
    }
    private Dictionary<InfoType, string> dictionary = new Dictionary<InfoType, string>();
    private UILabel label;
    private TweenAlpha tween;

    private float timerCoins = 0;
    private int comboCounter = 0;
    bool startTimer = false;
	// Use this for initialization
	void Start () {
        label = GetComponentInChildren<UILabel>();
        if (label == null)
            gameObject.AddComponent<UILabel>();
        label.text = "";
        tween = GetComponentInChildren<TweenAlpha>();
        dictionary.Add(InfoType.COIN, "Coin!");
        dictionary.Add(InfoType.DOUBLE, "Double!");
        dictionary.Add(InfoType.TRIPPLE, "Tripple!");
        dictionary.Add(InfoType.COIN_ATTACK, "Coin Attack!");
        dictionary.Add(InfoType.PRIZE, "Prize!");
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
        if (type == CollectionManager.CollectionType.COIN)
        {
            comboCounter++;
            startTimer = true;
            timerCoins = 0;
            if(comboCounter == 1)
                Info(InfoType.COIN);
            else if (comboCounter == 2)
                Info(InfoType.DOUBLE);
            else if (comboCounter == 3)
                Info(InfoType.TRIPPLE);
            else if (comboCounter >= 4)
                Info(InfoType.COIN_ATTACK);
        }
        else if (type == CollectionManager.CollectionType.PRIZE)
            Info(InfoType.PRIZE);
    }
    /*// Update is called once per frame
    void Update()
    {
        
    }*/
	// Update is called once per frame
	void Update () {
        if (startTimer)
            timerCoins += Time.deltaTime;

        if (timerCoins >= 2)
        {
            startTimer = false;
            comboCounter = 0;
        }
	}

    public void Info(InfoType type)
    {
        if (label)
            label.text = dictionary[type];
        if (tween)
        {
            tween.ResetToBeginning();
            tween.PlayForward();
        }
    }
}
