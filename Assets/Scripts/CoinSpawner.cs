using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour {
    public Transform Coin;
    public Transform CoinContainer;
    public float yValue= 4f;
    float CoinSpawnTimer = 0f;
    float CoinTimer = 20f;
	// Use this for initialization
	void Start () {
        //List<int> list = new List<int>();
	}
    //check if the mouse is hovering over the spawner area
    private void OnMouseOver()
    {
        if (Game.IsPaused()) return;
		//check if the mouse is down and if you have enough coins and the reload time is 0
		if ( Input.GetMouseButtonDown(0) && CollectionManager.instance.GetValue(CollectionManager.CollectionType.COIN) >= 1 && CoinSpawnTimer <= 0)
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hittest;
            Physics.Raycast(ray, out hittest, 200f);//, 1 << gameObject.layer);
            Vector3 correctedPoint = hittest.point;
            correctedPoint.y = yValue;
			//spawn the coin
            Transform create = (Transform)Instantiate(Coin);
		    if (create)
		    {
		        create.parent = CoinContainer;
                create.position = correctedPoint;
                create.rotation = new Quaternion(Random.Range(0f, .25f), Random.Range(-1f, 1f), 0f, 1f);
                //У новых монет ставим слой, попадающий под райкаст, чтобы тыкая на эту монету, добавлялась новая
                /*create.gameObject.layer = gameObject.layer;
                foreach (Transform trans in create.gameObject.GetComponentsInChildren<Transform>())
                    trans.gameObject.layer = gameObject.layer;//*/
		    }
            //remove 1 coin from the total amount of coins
            CollectionManager.instance.ChangeCoins(Action.Type.SPEND, 1);
			//set reload time to 0.5seconds
			CoinSpawnTimer = 0.5f;
		}
		else
		{
			CoinSpawnTimer -= Time.deltaTime;
        }
    }
}
