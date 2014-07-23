using UnityEngine;
using System.Collections;

public class Displayer : MonoBehaviour {
    public CollectionManager.CollectionType collectionType;
    UILabel label;
    // Use this for initialization
    void Start()
    { 
		label = gameObject.GetComponentInChildren<UILabel> ();
		if(label == null)
			label = gameObject.AddComponent<UILabel>();
        AddEvents();
        UpdateValue(CollectionManager.instance.GetValue(collectionType));
	}
    private void AddEvents()
    {
        CollectionManager.OnChange += OnChange;
    }

    private void OnChange(CollectionManager.CollectionType type, Action.Type actionType, int count, int changeValue)
    {
        if (type == collectionType)
            UpdateValue(count);
    }

    private void UpdateValue(int value)
    {
        if (label)
            label.text = value.ToString();
    }
}
