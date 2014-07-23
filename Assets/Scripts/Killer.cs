using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        //Is it a coin add 1 coin to the total coins
        if (other.CompareTag("Coin") || other.CompareTag("Prize"))
        {
            Destroy(other.gameObject);
        }
    }
}
