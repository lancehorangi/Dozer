using UnityEngine;
using System.Collections;

public class Resize : MonoBehaviour {
    public enum ScalingType
    {
        HEIGHT,
        WIDTH        
    }
    public ScalingType scalingType;
    public float targetSize = 320;
	// Use this for initialization
	void Start () {
        float manual = Mathf.RoundToInt(targetSize * ((float)Screen.height / Screen.width));
        transform.localScale *= ((scalingType == ScalingType.HEIGHT) ? Screen.height : Screen.width) / targetSize;

        
	}
}
