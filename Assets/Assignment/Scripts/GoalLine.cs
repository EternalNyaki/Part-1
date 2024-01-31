using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int minutes = (int) Time.realtimeSinceStartup / 60;
            int seconds = (int) Time.realtimeSinceStartup % 60;
            int millis = (int) (Time.realtimeSinceStartup % 1) * 1000;
            Debug.Log(minutes + ":" + seconds + "." + millis);
        }
    }
}