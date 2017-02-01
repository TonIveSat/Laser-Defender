﻿using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public int InitialHealth = 20;

    private int currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = InitialHealth;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitScript = collision.gameObject.GetComponent<PlayerProjectile>();
        if (hitScript != null)
        {
            Hit(hitScript.Damage);
            hitScript.Hit();
        }
    }

    private void Hit(int Damage)
    {
        print("Enemy Hit");
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
