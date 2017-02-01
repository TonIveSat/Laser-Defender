using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyLaserObject;

    public float LaserSpeed = 15;

    public float DeltaTime;

    public float FireRate = 0.5f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Random.value <  (Time.deltaTime * FireRate))
        {
            Fire();
        }
	}

    private void Fire()
    {
        GameObject laserbeam = Instantiate(EnemyLaserObject, transform.position, Quaternion.identity) as GameObject;
        laserbeam.GetComponent<Rigidbody2D>().velocity = Vector3.down * LaserSpeed;
    }
}
