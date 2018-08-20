using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool isJump;
    public Rigidbody ball;
    public GameObject partical1;
    public GameObject partical2;

    // 計算滑鼠移動距離用
    Vector2 click;
    Vector2 release;

    // 球所在位置，1為左，2為中，3為右
    int LeftMidRight = 2;

    // 球向前速度
    public static float ForwardPower=0.1f;

    void FixedUpdate()
    {
        float addFore = Score.scoreFloat / 1000;
        if (GameOver.gameOver == false)
        {
            transform.Translate(0, 0, ForwardPower + addFore);
            partical1.transform.position = new Vector3(0, 0, partical1.transform.position.z + ForwardPower + addFore);
            partical2.transform.position = new Vector3(0, 0, partical2.transform.position.z + ForwardPower + addFore);
        }
    }
    void Update()
    {

        // 球左中右
        if (LeftMidRight == 1)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
        if (LeftMidRight == 2)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (LeftMidRight == 3)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            click = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            release = Input.mousePosition;

            // 取滑鼠移動多少
            Vector2 goToWhr = click - release;
            if (goToWhr.x < 50 && goToWhr.y < goToWhr.x)
            {
                if (goToWhr.y < -50)
                {
                    Jump();
                }
            }
            else if (goToWhr.x < -50 && LeftMidRight <= 2)
            {
                LeftMidRight++;
            }
            else if (goToWhr.x > 50 && LeftMidRight >= 2)
            {
                LeftMidRight--;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && LeftMidRight >= 2)
        {
            LeftMidRight--;
        }
        if (Input.GetKeyDown(KeyCode.D) && LeftMidRight <= 2)
        {
            LeftMidRight++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            isJump = false;
        }
    }

    private void Jump()
    {
        if (isJump == false)
        {
            ball.AddForce(Vector2.up * 300);
            isJump = true;
        }
    }
}
