using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public double speed, jump, acceleration, accelerationIncrease, maxTime;
    Transform rayGround;
    Rigidbody2D rigidBody;
    float startTime;
    float timeNow;
    Text text;

    private float TimeResetX, TimeResetY;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        TimeResetX = transform.position.x;
        TimeResetY = transform.position.y;
        text = GameObject.Find("Canvas").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time - startTime;
        updateTimeLeft();
        movment();
        if (Input.GetKeyDown(KeyCode.E)) {
            transform.position = new Vector3(TimeResetX, TimeResetY, 0);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            acceleration += 5;
        }
        
    }

    void updateTimeLeft() {
        float timeLeft = (float)maxTime - timeNow;
        TimeSpan span = TimeSpan.FromSeconds((double)(new decimal(timeLeft)));
        text.text = span.ToString();
    }

    void movment() 
    {
        speed = Input.GetAxis("Horizontal") * acceleration;
        Vector2 direction = new Vector2((float)speed, 0);
        rigidBody.AddForce(direction);
    }

    public void accelIncrease() {
        acceleration *= (1 + accelerationIncrease);
    }

}
