using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Rock"))
        {
            collision.gameObject.GetComponent<Rock>().Direction.x *= -1;
            collision.gameObject.GetComponent<Rock>().Direction.y *= -1;
        }
        */ 

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().playerInput = Vector3.zero;
        }
    }
            
}
