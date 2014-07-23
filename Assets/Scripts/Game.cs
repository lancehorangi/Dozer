using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    public static void SetPause(bool value)
    {
        Time.timeScale = (value) ? 0f : 1f;
    }
    public static bool IsPaused(){
        return (Time.timeScale == 0f);
    }
}
