using UnityEngine;
using System.Collections;

public class ApplicationAction : MonoBehaviour
{
    public enum Action
    {
        EXIT
    }
    public Action action;

	void OnClick () {
        if(action == Action.EXIT)
            Application.Quit();
	}
}
