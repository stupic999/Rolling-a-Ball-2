using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public GUIText scoreText;
    public GameObject ball;

    public static float scoreFloat;
    private int scoreTotal;
    float startPosition;
    float nowPosition;

	// Use this for initialization
	void Start () {
        startPosition = ball.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        nowPosition= ball.transform.position.z;

        // 計分方式=跑出多遠/10+吃多少金幣*5
        scoreFloat = nowPosition - startPosition/10;
        scoreTotal = (int)scoreFloat + Coin.scoreCoin;
        scoreText.text = ("Score:")+scoreTotal.ToString();
        
	}
}
