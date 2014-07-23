using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
    
    public static Stage instance;
    public enum ShakeType
    {
        OX, OZ, BOTH
    }
    public float startingShakeDistance = .5f;
    public float decreasePercentage = .5f;
    public float shakeSpeed = 80;
    public int numberOfShake = 5;
    public ShakeType shakeType = ShakeType.BOTH;
    public bool byRigidbody = false;
    private bool isShaking = false;
    private void Start()
    {
    }
	// Use this for initialization
    public void ShakeStage()
    {
        if(isShaking == false)
            StartCoroutine(StartShake());
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

    private IEnumerator StartShake()
    {
        float hitTime = Time.time;
        Vector3 originalPosition = transform.localPosition;
        var shake = numberOfShake;
        float shakeDistance = startingShakeDistance;
        isShaking = true;
        while (shake > 0)
        {
            float timer = (Time.time - hitTime) * shakeSpeed;
            if(byRigidbody)
                rigidbody.MovePosition(
                    new Vector3(
                    originalPosition.x + (float)((shakeType == ShakeType.OX || shakeType == ShakeType.BOTH) ? (Mathf.Sin(timer) * shakeDistance) : 0),
                    originalPosition.y + Mathf.Sin(timer) * .05f,
                    originalPosition.z + (float)((shakeType == ShakeType.OZ || shakeType == ShakeType.BOTH) ? (Mathf.Cos(timer) * shakeDistance) : 0))
                    );
            else
                transform.localPosition =
                    new Vector3(
                    originalPosition.x + (float)((shakeType == ShakeType.OX || shakeType == ShakeType.BOTH) ? (Mathf.Sin(timer) * shakeDistance) : 0),
                    originalPosition.y + Mathf.Sin(timer) * .05f,
                    originalPosition.z + (float)((shakeType == ShakeType.OZ || shakeType == ShakeType.BOTH) ? (Mathf.Cos(timer) * shakeDistance) : 0))
                    ;
            if (timer > Mathf.PI * 2)
            {
                hitTime = Time.time;
                shakeDistance *= decreasePercentage;
                shake--;
            }
#if UNITY_ANDROID && !UNITY_EDITOR
            Vibration.Vibrate(10000);
#endif
            yield return null;
        }
        #if UNITY_ANDROID && !UNITY_EDITOR
            Vibration.Cancel();
        #endif
        transform.localPosition = originalPosition;
        isShaking = false;
    }

    public static void Shake()
    {
        if (instance) instance.ShakeStage();
    }
}
