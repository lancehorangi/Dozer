using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    //необходимый опыт до следующего уровня, суммарно
    public float _basedRequiredXpToNextLevel = 20;
    public float _xpScale = 1.1f;

    //Делегаты и события
    public delegate void LevelUpHandler(int level);
    public static event LevelUpHandler OnLevelUp;
    public delegate void IncreaseXPHandler(float xp, float prevXP, float targetXP);
    public static event IncreaseXPHandler OnIncreaseXP;

    //PRIVATE
    private float _xp = 0;
    private int _level = 1;
    private float _targetXP;
    //необходимый опыт в текущем уровне
    private float _requiredXpOfCurrLevel;

	// Use this for initialization
	void Start () {
        _requiredXpOfCurrLevel = _targetXP = _basedRequiredXpToNextLevel;
        CollectionManager.OnChange += OnChange;
        try { OnLevelUp(_level); }  catch { };
        IncreaseXP(0);
	}
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void OnChange(CollectionManager.CollectionType type, Action.Type actionType, int count, int changeValue)
    {
        if (type == CollectionManager.CollectionType.COIN && actionType == Action.Type.ADD)
            IncreaseXP(changeValue);
    }

    //Добавить опыт
    private void IncreaseXP(int value)
    {
        _xp += value;
        if (_xp >= _targetXP)
        {
            _requiredXpOfCurrLevel *= _xpScale;
            _targetXP += _requiredXpOfCurrLevel;
            try { OnLevelUp(++_level); }
            catch { };
        }
        try { OnIncreaseXP(_xp, prevXP, targetXP); }
        catch { };
    }

    //Уровни и опыт
    public int level
    {
        get { return _level; }
    }

    //текущий накопленный опыт
    public float xp
    {
        get { return _xp; }
    }
    //необходимый опыт в текущем уровне
    public float targetXP
    {
        get { return _targetXP; }
    }

    //необходимый опыт в текущем уровне
    public float prevXP
    {
        get { return (_targetXP - _requiredXpOfCurrLevel); }
    }
}
