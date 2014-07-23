using UnityEngine;
using System.Collections;

public class ShakeTable : MonoBehaviour
{
    
    public enum ActionType
    {
        CLICK,
        PRESS
    }
    public ActionType actionType = ActionType.CLICK;
    public void OnClick()
    {
        if(actionType == ActionType.CLICK)
            Stage.Shake();
    }

    public void OnPress()
    {
        if (actionType == ActionType.PRESS)
            Stage.Shake();
    }
}
