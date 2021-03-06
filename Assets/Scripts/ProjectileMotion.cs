﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float xBoundary;
    public float yBoundary;

    public int id;

    public PlayerProjectileManager Guns;

    [SerializeField]
    float speed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(transform.up * speed);
        if (rb == null)
        {
            Debug.Log("RigidBody ref is null");
        }
        //Fire();

    }

    public void Fire()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.up * speed * Time.deltaTime);
        Guns = FindObjectOfType<PlayerProjectileManager>();

        CheckBounds();
    }

    void CheckBounds()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if( x > xBoundary || x < -xBoundary || y > yBoundary || y < - yBoundary)
        {
            Guns.Reload(gameObject);
        }
    }
}
