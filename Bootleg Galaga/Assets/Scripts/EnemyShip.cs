﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = GameManager.instance.player.transform.position;
        Vector3 directionToLook = targetPosition - transform.position;
        // transform.right = directionToLook;
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), rotationSpeed * Time.deltaTime);
    }
}