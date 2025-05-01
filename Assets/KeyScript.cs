using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
     Agent playerScript;

    // Start is called before the first frame update
    void Start()
    {
          playerScript = GameObject.Find("Player").GetComponent<Agent>();
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.gameObject.name == "Player")
          {
               playerScript.hasKey = true;
               Destroy(gameObject);
          }
     }
}
