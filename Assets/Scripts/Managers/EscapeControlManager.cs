using UnityEngine;
using System.Collections.Generic;

public class EscapeControlManager : MonoBehaviour {
    private static EscapeControlManager _instance;
    private List<GameObject> closeButtonsList = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
    private void Awake()
    {
        instance = this;
    }
    public static EscapeControlManager instance
    {
        get{
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load("_EscapeControlManager", typeof(EscapeControlManager))) as EscapeControlManager;
            }
            return _instance;
        }
        set
        {
            if (_instance != null)
            {
                Destroy(value.gameObject);
                return;
            }
            _instance = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (lastButton)
            {
                lastButton.SendMessage("OnClick");
                Remove(lastButton);
                /*if (closeButtonsList.Count == 0)
                    Application.Quit();*/
            }
        }
    }

    private GameObject lastButton
    {
        get
        {
            return (closeButtonsList.Count > 0) ? closeButtonsList[closeButtonsList.Count - 1] : null;
        }
    }
    public void Add(GameObject button)
    {
        if (button == null) 
            return;
        closeButtonsList.Add(button);
    }

    public void Remove(GameObject button)
    {
        if (button == null) 
            return;
        closeButtonsList.Remove(button);
    }

    public static void AddButton(GameObject button)
    {
        EscapeControlManager.instance.Add(button);
    }

    public static void RemoveButton(GameObject button)
    {
        EscapeControlManager.instance.Remove(button);
    }
}
