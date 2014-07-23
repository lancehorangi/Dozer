using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {
    public delegate void CollectHandler(CollectionManager.CollectionType type);
    public static event CollectHandler OnCollect;

	// Use this for initialization
	void Start () {
	
	}
	
    private void OnTriggerEnter(Collider other)
    {
        //Is it a coin add 1 coin to the total coins
        if (other.CompareTag("Coin"))
        {
            try { OnCollect(CollectionManager.CollectionType.COIN); }   catch{};
        }

        //Is it a price taged object than add 1 to the total price score
        if (other.CompareTag("Prize"))
        {
            try { OnCollect(CollectionManager.CollectionType.PRIZE); }  catch{};
        }
    }
}