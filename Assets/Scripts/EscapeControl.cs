using UnityEngine;
using System.Collections;

public class EscapeControl : MonoBehaviour {

    void OnEnable()
    {
        EscapeControlManager.AddButton(gameObject);
    }

    void OnDisable()
    {
        EscapeControlManager.RemoveButton(gameObject);
    }
}

