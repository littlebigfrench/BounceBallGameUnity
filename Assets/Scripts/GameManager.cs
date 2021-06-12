using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float NumberOfBalls = 0;
    public float BallInScnene = 0;
    public GameObject ballPrefab;
    public GameObject ballsContainer;

    public GameObject wallPrefab;

    public TextMeshProUGUI textBallsInCup;

    public double[] barXPos;
    public double[] barYPos;

    public float barWideReference = 0.4f;

    void Start()
    {
        barXPos = new double[]
        {
            -1.5,
            -0.5,
            0.5,
            1.5,
        };
        barYPos = new double[]
        {
            -1,
            0,
            1,
            2,
            3,
        };

        GenerateWalls();

        /*GameObject instance = Instantiate(ballPrefab, new Vector3(0.23f, 4.2293f, 0), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ballsContainer.transform, true);
        instance.GetComponent<Ball>().gamemanager = this;

        instance = Instantiate(ballPrefab, new Vector3(0.23f, 4.2293f, 0), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ballsContainer.transform, true);
        instance.GetComponent<Ball>().gamemanager = this;

        instance = Instantiate(ballPrefab, new Vector3(0.23f, 4.2293f, 0), Quaternion.identity) as GameObject;
        instance.transform.SetParent(ballsContainer.transform, true);
        instance.GetComponent<Ball>().gamemanager = this;*/

    }
    void FixedUpdate()
    {
        textBallsInCup.text = NumberOfBalls+"";
    }
    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
    private void GenerateWalls()
    {
        int numberOfWallsY = UnityEngine.Random.Range(1, barYPos.Length-1);
        int numberOfWallsX = UnityEngine.Random.Range(1, barXPos.Length-1);

        double[] barYPos_ = new double[numberOfWallsY];
        double[] barXPos_ = new double[numberOfWallsX];

        for (int x = 0; x <= numberOfWallsX - 1; x++)
        {
            int random = 0;
            if (barXPos_.Length > 0)
            {
                for (int xx = 0; xx <= barXPos_.Length - 1; xx++)
                {
                    while (barXPos_[xx] != barXPos[random])
                    {
                        random = UnityEngine.Random.Range(1, barXPos.Length - 1);
                    }
                    barXPos_[x] = barXPos[random];
                }
            }
            else
            {
                random = UnityEngine.Random.Range(1, barXPos.Length - 1);
                barXPos_[x] = barXPos[random];
            }
        }
        Debug.Log(barXPos_);
        /*
        for (int x = 0; x <= barXPos_.Length - 1; x++)
        {
            for (int y = 0; y <= barYPos_.Length - 1; y++)
            {

            }
        }*/
    }
    private void OnDrawGizmos()
    {
        if (barXPos != null && barYPos != null)
            return;

        for (int x = 0; x <= barXPos.Length-1; x++)
        {
            for (int y = 0; y <= barYPos.Length-1; y++)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(new Vector3((float)barXPos[x], (float)barYPos[y], 6), .05f);
            }
        }
    }
}
