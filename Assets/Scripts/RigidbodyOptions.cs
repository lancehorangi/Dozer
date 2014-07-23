using UnityEngine;
using System.Collections;

public class RigidbodyOptions : MonoBehaviour {
    public bool detectCollisions = true;
    public bool useConeFriction = false;
    public bool allChilds = false;
	// Use this for initialization
    void Start()
    {
        if (allChilds)
        {
            Rigidbody[] rigidBodyes = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody r in rigidBodyes)
            {
                r.detectCollisions = detectCollisions;
                r.useConeFriction = useConeFriction;
            }
        }
        else if (rigidbody)
        {
            rigidbody.detectCollisions = detectCollisions;
            rigidbody.useConeFriction = useConeFriction;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
