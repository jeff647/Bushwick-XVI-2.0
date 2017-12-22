using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    private float projectileForce = 750f;

    private Animator _animator = null;

    public Transform firepoint;

	private Transform _transform;
    public Camera cam;
	// Use this for initialization
	void Start () {
        _animator = gameObject.GetComponent<Animator>();
		_transform = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("fire");
            FireProjectile();
        }
	}

    void FireProjectile()
    {
        GameObject p = Instantiate(projectile, firepoint.position, Quaternion.identity);
        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();

        rb.AddForce(firepoint.right * projectileForce * _transform.localScale.x);
        p.transform.localScale = firepoint.localScale;
    }
}
