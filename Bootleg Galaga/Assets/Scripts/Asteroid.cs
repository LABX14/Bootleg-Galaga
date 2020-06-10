using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I'm touching something!");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject == GameManager.instance.player)
        {
            Debug.Log("Ran into player game object");
            // This is what happens if the players hits an asteroid.
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("I'm not touching something!");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("I'm still touching something!");
    }
}
