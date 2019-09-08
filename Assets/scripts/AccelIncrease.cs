using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelIncrease : MonoBehaviour
{

    // Start is called before the first frame update
   GameObject tileMap;
    void Start()
    {
        tileMap = GameObject.Find("sprt");
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D p) {
        if (p.tag == "Player") {
            Player player = p.GetComponent<Player>();
            if (player != null) player.accelIncrease();
        }
    }
}
