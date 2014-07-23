using UnityEngine;
using System.Collections;

public class LevelDisplayer : MonoBehaviour
{
    public UILabel labelXP;
    public UILabel labelLevel;
    public UISlider slider;
    // Use this for initialization
    void Awake()
    {
        if(slider == null)
            slider = (gameObject.GetComponentInChildren<UISlider>() ?? GetComponent<UISlider>()) ?? gameObject.AddComponent<UISlider>();
        AddEvents();
    }
    private void AddEvents()
    {
        LevelManager.OnIncreaseXP += OnIncreaseXP;
        LevelManager.OnLevelUp += OnLevelUp;
    }

    private void OnIncreaseXP(float xp, float prevXP, float targetXP)
    {
        if (labelXP)
            labelXP.text = string.Format("{0}/{1}", xp, targetXP);
        if (slider)
            slider.value = (xp - prevXP)/(targetXP - prevXP);
    }

    private void OnLevelUp(int value)
    {
        if (labelLevel)
            labelLevel.text = value.ToString();
    }
}
