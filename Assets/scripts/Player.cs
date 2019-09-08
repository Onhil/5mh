using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public double jump, acceleration, accelerationIncrease, maxTime, coolDown;
    [SerializeField]
    Transform rayGround;
    Rigidbody2D rigidBody;
    float startTime;
    float timeNow;
    Text text;
    bool isGrounded = true;
    bool travelled = false;
    float timeLeft;
    float travelTime;
    float travelledStart;
    float travelledNow;
    float travelledLeft ;

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
        travel();
        movment();
        CheckGround();
        
        if (Input.GetKeyDown(KeyCode.F)) {
            acceleration += 5;
        }
        
    }

    void travel() {
        if (Input.GetKeyDown(KeyCode.E) && !travelled) {
            transform.position = new Vector3(TimeResetX, TimeResetY, 0);
            travelled = true;
            travelTime = timeLeft;
            Debug.Log(travelTime);
            travelledStart = Time.time;
        }
        
        
        if ((travelTime - coolDown) >= timeLeft && travelled) {
            travelled = false;
            Debug.Log(timeLeft);
        }
    }

    void updateTimeLeft() {
        timeLeft = (float)maxTime - timeNow;
        TimeSpan span = TimeSpan.FromSeconds((double)(new decimal(timeLeft)));
        if (travelled) {
            
            travelledNow = Time.time - travelledStart;
            travelledLeft = (float)coolDown - travelledNow;
        }
        if (travelledLeft < 0) {
            travelledLeft = 0;
        }
        text.text = "Time left: " + span.ToString() + "\n" + "Score: " + ((acceleration - 10) * 4).ToString() + "\nCooldown: " + travelledLeft.ToString();
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
