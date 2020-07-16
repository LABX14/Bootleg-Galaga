using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 directionToMove;
    private Vector3 targetPosition;
    public float moveSpeed;
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();
        targetPosition = GameManager.instance.player.transform.position;
        // EventBroker.PlayerDied += DestroySelf;
    }

    private void Update()
    {
        transform.position += directionToMove * moveSpeed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position,targetPosition, 0.1f);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
        EventBroker.PlayerDied -= DestroySelf;
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("I'm touching something!");
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("Ran into player game object");
            // This is what happens if the players hits an asteroid.
        }

        //Destroy bullet when it hits asteroid
        if (otherObject.gameObject.GetComponent<Bullet>())
        {
            GameManager.instance.enemyList.Remove(this.gameObject);

            Destroy(this.gameObject);
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
