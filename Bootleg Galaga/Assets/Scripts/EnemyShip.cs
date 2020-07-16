using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    public float rotateSpeed; // designer friendly var to hold rotation speed
    public float moveSpeed; //designer friendly var to hold move speed of asteroid

    private Transform tf; // var to hold my transform

    // var to hold start position vector of asteroid
    private Vector3 myStartPosition;
    // var to hold position of player (destination)
    private Vector3 playerStartPosition;
    // var to hold vector, calculate direction to travel
    private Vector3 directionVector;
    // var to hold and calculate direction and speed for movement
    private Vector3 moveVector;

    private Vector3 myStartRotation; // var to hold start rotation vector of asteroid
    private Vector3 playerStartRotation; // var to hold rotation of player (destination)
    private float angle; // var to hold float, calculate angle to travel
    Quaternion targetRotation; // var to hold and calculate rotation

    // Use this for initialization
    void Start()
    {

        //Assign variables
        tf = GetComponent<Transform>(); // load my transform component into variable tf


    }

    // Update is called once per frame
    void Update()
    {
        //If the player object can be referenced
        if (GameManager.instance.player != null)
        {
            //Update variables every frame
            myStartPosition = tf.position; // store my position on every frame
            playerStartPosition = GameManager.instance.player.gameObject.transform.position; //store position of player on every frame

            directionVector = playerStartPosition - myStartPosition; //store diff between player and asteroid as direction on every frame
            directionVector.Normalize(); // normalize the vector to a magnitude of 1

            moveVector = directionVector * moveSpeed; //calculate the new vector

            //Move towards the point where the player was on start
            tf.position += moveVector; //move in that direction each frame at given speed on every frame


            //ROTATION

            angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg; //calculate angle based on direction to player
            targetRotation = Quaternion.Euler(0, 0, angle); //update angle to rotate towards
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime); //gradually rotate towards angle times speed
        }



    }
}
