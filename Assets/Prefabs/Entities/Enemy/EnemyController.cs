using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyLaserObject;

    public float LaserSpeed = 15;

    public float DeltaTime;

    public float FireRate = 0.5f;

    public AudioClip FireringSound;

    public float InitialFireDelay = 2f;

    private System.DateTime birthTime;

    private bool passiveMode = true;

    // Use this for initialization
    void Start ()
    {
        birthTime = System.DateTime.Now;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (passiveMode)
        {
            if (birthTime.AddSeconds(InitialFireDelay) < System.DateTime.Now)
            {
                passiveMode = false;
            }
        }
        else
        {
            if (Random.value < (Time.deltaTime * FireRate))
            {
                Fire();
            }
        }
	}

    private void Fire()
    {
        GameObject laserbeam = Instantiate(EnemyLaserObject, transform.position, Quaternion.identity) as GameObject;
        laserbeam.GetComponent<Rigidbody2D>().velocity = Vector3.down * LaserSpeed;
    }
}
