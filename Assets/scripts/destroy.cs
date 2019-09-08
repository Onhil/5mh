using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    private float TimeResetX, TimeResetY;
    // Start is called before the first frame update
    void Start()
    {
        TimeResetX = transform.position.x;
        TimeResetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D p) {
        if (p.tag == "Player") {
            Player player = p.GetComponent<Player>();
            if (player != null) player.accelIncrease();
            transform.position = new Vector3(0, 300, 0);
        }
    }

    public void move() {
        transform.position = new Vector3(TimeResetX, TimeResetY, 0);
    }
}
