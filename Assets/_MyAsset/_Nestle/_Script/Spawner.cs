using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject ParentReset;
    public GameObject BallTarget1, BallTarget2, BallTarget3;
	// Use this for initialization
	public void SpawnObject (int WhatBall) {
        if (WhatBall == 1)
        {
            var myNewSmoke = Instantiate(BallTarget1, new Vector3(ParentReset.transform.position.x, ParentReset.transform.position.y, ParentReset.transform.position.z), Quaternion.identity);
            myNewSmoke.name = "Target1";
            myNewSmoke.GetComponent<Rigidbody>().velocity = myNewSmoke.GetComponent<Rigidbody>().velocity * 0.9f;
            myNewSmoke.transform.parent = gameObject.transform;
        }
        if (WhatBall == 2)
        {
            var myNewSmoke = Instantiate(BallTarget2, new Vector3(ParentReset.transform.position.x, ParentReset.transform.position.y, ParentReset.transform.position.z), Quaternion.identity);
            myNewSmoke.name = "Target2";
            myNewSmoke.GetComponent<Rigidbody>().velocity = myNewSmoke.GetComponent<Rigidbody>().velocity * 0.9f;
            myNewSmoke.transform.parent = gameObject.transform;
        }
        if (WhatBall == 3)
        {
            var myNewSmoke = Instantiate(BallTarget3, new Vector3(ParentReset.transform.position.x, ParentReset.transform.position.y, ParentReset.transform.position.z), Quaternion.identity);
            myNewSmoke.name = "Target3";
            myNewSmoke.GetComponent<Rigidbody>().velocity = myNewSmoke.GetComponent<Rigidbody>().velocity * 0.9f;
            myNewSmoke.transform.parent = gameObject.transform;
        }

    }
	
	
}
