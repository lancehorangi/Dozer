using UnityEngine;
using System.Collections;

public class PrizeSpawner : MonoBehaviour {
    public enum PrizeType
    {
        PRIZE01,
        PRIZE02,
        PRIZE03
    }
    public Transform Price01;
    public Transform Price02;
    public Transform Price03;
    public Transform CoinContainer;
    private Transform clone;
	// Use this for initialization
	void Start () {
        StartCoroutine(StartSpawn());
	}

    private IEnumerator StartSpawn()
    {
	    //spawn the price
		SpawnPrice01();
		//wait 50 seconds and spawn price02
		yield return new WaitForSeconds(50);
		SpawnPrice02();
		//wait 70 seconds and spawn price03
        yield return new WaitForSeconds(70);
		SpawnPrice03();
    }
    public void SpawnPrize(PrizeType type)
    {
        Transform newPrize = null ;
        float zValue = Random.Range(-7, -10);
        switch (type)
        {
            case PrizeType.PRIZE01:
            newPrize = Price01;
            break;
            case PrizeType.PRIZE02:
            newPrize = Price02;
            break;
            case PrizeType.PRIZE03:
            newPrize = Price03;
            zValue = Random.Range(-4, -5);
            break;
        }
        if (newPrize)
        {
            clone = (Transform)Instantiate(newPrize);
            clone.rigidbody.angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, -1), zValue);
            //spawn the coin
            if (clone)
            {
                clone.parent = CoinContainer;
                clone.position = new Vector3(Random.Range(-1, 1), transform.localPosition.y, transform.localPosition.z);
                clone.rotation = Quaternion.identity;
            }
        }
        
    }
    //Spawn price01
    public void SpawnPrice01()
    {
        SpawnPrize(PrizeType.PRIZE01);
        //Wait to repeat this and spawn the next Price01 
        Invoke("SpawnPrice01", 100);
    }

    //Spawn price02
    public void SpawnPrice02()
    {
        SpawnPrize(PrizeType.PRIZE02);
        //Wait to repeat this and spawn the next Price02
        Invoke("SpawnPrice02", 200);
    }

    //Spawn price03
    public void SpawnPrice03()
    {
        SpawnPrize(PrizeType.PRIZE03);
        //Wait to repeat this and spawn the next Price03
        Invoke("SpawnPrice03", 300);
    }
}
