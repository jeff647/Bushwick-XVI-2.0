﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    private float projectileForce = 750f;

    private Animator animator = null;

    public Transform firepoint;

	private Transform transform;

    public Camera cam;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
		transform = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("fire");
            FireProjectile();
        }
	}

    void FireProjectile()
    {
        GameObject p = Instantiate(projectile, firepoint.position, Quaternion.identity);
        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();

        rb.AddForce(firepoint.right * projectileForce * transform.localScale.x);
        p.transform.localScale = firepoint.localScale;
    }
}
