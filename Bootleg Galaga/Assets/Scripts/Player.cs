using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float turnSpeed = 90f; // Degrees per second
    public float moveSpeed = 5f; //Meters per second
    public GameObject bulletPrefab;
    private Transform change;
    public float bulletSpeed = 6f;

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

    // This spawns in the bullet and makes it shoot from the ship.  
    public void Shoot()
    {
        // You CAN do it this way, but it's long, and you shouldn't. 
        // GameObject bullet = new GameObject();
        // SpriteRenderer bulletSpriteRenderer = bullet.AddComponent<SpriteRenderer>() as SpriteRenderer;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        Destroy(bullet, 2);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player runs into something, they should die
        Die();
    }

    void Die()
    {
        // TODO: Write death code here. 
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.player = null;
    }
}

