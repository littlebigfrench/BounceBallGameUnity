using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public float multiplier;
    GameObject obj;
    public GameManager gamemanager;

    public int globalBallMultiplied = 0;
    public int BallToSpawn = 0;

    Dictionary<int, Vector3> ballsToClone = new Dictionary<int, Vector3>();
    private void Start()
    {
        multiplier = Random.Range(2, 20);
        obj = transform.gameObject;
        obj.GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = "X"+multiplier;
    }
    private void FixedUpdate()
    {
        DuplicateLoop();
    }
    private void DuplicateLoop()
    {
        if (gamemanager.BallInScnene < 40f && BallToSpawn >= 1)
        {
            GameObject instance = Instantiate(gamemanager.ballPrefab, transform.position + new Vector3( (transform.position.x + Random.Range( transform.position.x / 1.5f, transform.position.x / 2) ) / 2, -1, 0) / 2, Quaternion.identity) as GameObject;
            instance.transform.SetParent(gamemanager.ballsContainer.transform, true);
            instance.GetComponent<Ball>().gamemanager = gamemanager;
            instance.GetComponent<Ball>().lastMultiplier = gameObject;
            BallToSpawn--;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Ball>().lastMultiplier != gameObject)
        {
            collider.gameObject.GetComponent<Ball>().lastMultiplier = gameObject;
            int xx = 0;
            globalBallMultiplied++;
            for (var i = 0; i < multiplier - 1; i++)
            {
                BallToSpawn++;
                xx++;
            }
            Debug.Log(xx+" added to table");
        }
    }
}
