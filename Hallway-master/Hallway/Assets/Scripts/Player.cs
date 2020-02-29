using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Player : MonoBehaviour
{

    public float timeLeft;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        SetTimeText();
        if (timeLeft <= 0.01)
        {
            SetTimeText();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            //gameObject.SetActive(false);
        }
    }

    void SetTimeText()
    {
        timeText.text = "Time: " + timeLeft.ToString("f0");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //gameObject.SetActive(false);
        }

    }


}