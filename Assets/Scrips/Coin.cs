using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: MonoBehaviour {

    public int rotateSpd;

    public static int scoreCoin;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateSpd, 0, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scoreCoin+=5;
            Destroy(gameObject);
        }
    }
}
