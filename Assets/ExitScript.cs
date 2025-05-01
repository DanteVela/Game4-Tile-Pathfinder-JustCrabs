using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
     // Variable for Win Status
    private Text _WinStatus;

    void Start()
    {
        // Keep GameStatus, if Player reaches the exit: Display Win Status
        _WinStatus = GameObject.Find("GameStatus").GetComponent<Text>();

        // Disable Text until Player reaches the exit
        _WinStatus.enabled = false;
    }
     private void Update()
     {
          
     }
     void OnTriggerEnter2D(Collider2D collision)
     {
          if(collision.gameObject.name == "Player")
          {
               //SEND ME TO THE WIN SCENE/STATE
               // Destroy(gameObject); //This is just to test the collision. Change this to changing a scene.
               
               // When Player dies, re-enable text and display _WinStatus
               _WinStatus.text = "You Win!";
               _WinStatus.enabled = true;
               Time.timeScale = 0;
          }
     }
}
