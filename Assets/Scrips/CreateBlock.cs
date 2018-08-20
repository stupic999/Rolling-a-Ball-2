using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour {

    public GameObject blocklow;
    public GameObject blockhigh;
    public GameObject coin;
    public int howFar=100;

    int randomRight;
    int randomMid;
    int randomLeft;

    private void Start()
    {
        int startHowFar = howFar;
        for (int i = 20; i < startHowFar; i += 10)
        {
            howFar = i;
            CreateStart();
        }
    }

    private void FixedUpdate()
    {
        int nowPosition = (int)transform.position.z;
        if (nowPosition+100 > howFar)
        {
            howFar += 10;
            CreateStart(); 
        }
    }

    void Create(int LeftMidRight,int positionx) {
        if (LeftMidRight == 1)
        {
            Instantiate(coin, new Vector3(positionx, 0.5f, transform.position.z + howFar), Quaternion.Euler(0,-90,-90));
        }
        if (LeftMidRight == 2)
        {
            Instantiate(blocklow, new Vector3(positionx-1, -0.5f, transform.position.z + howFar), transform.rotation);
        }
        if (LeftMidRight == 3)
        {
            Instantiate(blockhigh, new Vector3(positionx-1, -0.5f, transform.position.z + howFar), transform.rotation);
        }
    }

    void CreateStart() {
        int randomPlace = UnityEngine.Random.Range(1, 4);
        switch (randomPlace)
        {
            case (1):
                Create(1, -3);
                randomMid = UnityEngine.Random.Range(1, 4);
                Create(randomMid, 0);
                randomLeft = UnityEngine.Random.Range(1, 4);
                Create(randomLeft, 3);
                break;
            case (2):
                Create(1, 0);
                randomRight = UnityEngine.Random.Range(1, 4);
                Create(randomRight, -3);
                randomLeft = UnityEngine.Random.Range(1, 4);
                Create(randomLeft, 3);
                break;
            case (3):
                Create(1, 3);
                randomMid = UnityEngine.Random.Range(1, 4);
                Create(randomMid, 0);
                randomRight = UnityEngine.Random.Range(1, 4);
                Create(randomRight, -3);
                break;
        }
    }
}
