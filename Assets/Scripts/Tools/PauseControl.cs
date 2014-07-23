using UnityEngine;
using System.Collections;

public class PauseControl : MonoBehaviour {
    public bool onEnable = true;
    public bool onDisable = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        if(onEnable)    Game.SetPause(true);
    }

    void OnDisable()
    {
        if (onDisable)  Game.SetPause(false);
    }
}
