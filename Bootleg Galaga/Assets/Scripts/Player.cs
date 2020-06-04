using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float turnSpeed = 90f; // Degrees per second
    public float moveSpeed = 5f; //Meters per second
    private Transform change;

    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.player = this.gameObject;
        change = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        // This will make the ship shoot when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        // TOD): Implement shooting.
        Debug.Log("Shooting not implemented yet.");
    }

    public void HandleRotation()
    {
        // This rotatees the ship to the left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        // This rotates the ship to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
    }
}

