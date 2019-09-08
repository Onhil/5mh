using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public double jump, acceleration, accelerationIncrease, maxTime;
    [SerializeField]
    Transform rayGround;
    Rigidbody2D rigidBody;
    float startTime;
    float timeNow;
    Text text;
    bool isGrounded = true;

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
        CheckGround();
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
        double speed = Input.GetAxis("Horizontal") * acceleration;

        if (isGrounded && Input.GetButtonDown("Jump")) {
            rigidBody.velocity = Vector2.up * (float)jump;
        } 
        rigidBody.velocity = new Vector2((float)speed, rigidBody.velocity.y);
        // Vector2 direction = new Vector2((float)hor, 0);
        // rigidBody.AddForce(direction);
        
    }

    public void accelIncrease() {
        // Max accel so its still playable without bouncing 
        if (acceleration < 100) 
        acceleration += accelerationIncrease;
    }

    void CheckGround()
    {
        //Sends a raystraight down 0.1 blocks
        RaycastHit2D hitDown = Physics2D.Raycast(rayGround.position, Vector2.down, 0.1f);
        //Chcks if ray hits ground
        if (hitDown)
        {
            isGrounded = true;
        } else isGrounded = false;
    }

}
