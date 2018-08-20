using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlimitate : MonoBehaviour {

    public GameObject Floor;
    public Vector3 transport;
    public Vector3 positionNow;

    private void OnTriggerEnter(Collider other)
    {
        // 無限跑道
        positionNow = Floor.transform.position;
        Floor.transform.position = positionNow + transport;
    }
}
