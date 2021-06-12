using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Vector2 velocity = Vector2.zero;

    public GameObject text;
    public Button button;
    private bool AnimateName;
    void Start()
    {
        button.onClick.AddListener(PlayGame);
    }
    private float next = 0;
    void FixedUpdate()
    {
        if (AnimateName == true)
        {
            text.transform.position = Vector2.SmoothDamp(text.transform.position, new Vector2(text.transform.position.x, Time.deltaTime / 50 + 0.2f / Screen.height), ref velocity, 0.1f);
            if (next == 0)
            {
                next = Time.time + 1f;
            }
            if (Time.time > next && next != 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            }
        }
    }
    public void PlayGame()
    {
        AnimateName = true;
    }
}
