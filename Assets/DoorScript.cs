using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
     Agent playerScript;
     Vector2 SELF_EXTENTS;

    // Start is called before the first frame update
    void Start()
    {
          playerScript = GameObject.Find("Player").GetComponent<Agent>();
          SELF_EXTENTS = GetComponent<BoxCollider2D>().bounds.extents;
     }

     private void OnTriggerStay2D(Collider2D collision)
     {
          if(collision.gameObject.name == "Player")
          {
               if (playerScript.hasKey) //If the player has the key...
               {
                    Destroy(gameObject);
               }
               else //If the player doesn't have the key...
               {
                    //Note: Shameless rip-and-convert from Game03
                    // get the bounds of the player
                    Vector2 extents = collision.GetComponent<BoxCollider2D>().bounds.extents;

                    // store the difference in position, we'll need the signs later
                    Vector2 dist = transform.position - collision.transform.position;

                    // get the absolute overlap distances (overlaps indicated by negative values)
                    Vector2 overlap = new Vector2(Mathf.Abs(dist.x), Mathf.Abs(dist.y)) - (extents + SELF_EXTENTS);

                    // only need to act if both x and y overlap (separating axis theorem)
                    if (overlap.x < 0 && overlap.y < 0)
                    {
                         // as an approximation, push out along the axis with the smaller overlap distance (bigger negative)
                         if (overlap.y > overlap.x)
                         {
                              // less overlap in y, push vertical (use saved sign to know which direction to push)
                              collision.transform.position = collision.transform.position + new Vector3(0f, (overlap.y) * Mathf.Sign(dist.y), 0f);
                         }
                         else
                         {
                              // less overlap in x, push horizontal
                              collision.transform.position = collision.transform.position + new Vector3((overlap.x) * Mathf.Sign(dist.x), 0f, 0f);
                         }
                    }
                    playerScript._path = null; //Kill waypoint array (Aka. movement)
               }
          }
     }
}
