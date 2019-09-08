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

            dTileMap destroyabale = gameObject.GetComponent<dTileMap>();

            if (!Equals(destroyabale, null)) {
                Vector2 grandma = (Vector2)player.transform.position;
                destroyabale.Destroy(player, grandma);
            }
        }
    }
}
