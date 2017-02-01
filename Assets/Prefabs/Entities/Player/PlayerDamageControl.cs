using UnityEngine;

public class PlayerDamageControl : MonoBehaviour
{
    public int InitialHealth = 20;

    private int currentHealth;

	void Start ()
    {
        currentHealth = InitialHealth;
    }

    void Update ()
    {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitScript = collision.gameObject.GetComponent<EnemyProjectile>();
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
            new LevelManager().LoadLevel("Lose");
            Destroy(gameObject);
        }
    }
}
