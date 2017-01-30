using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Laser;

    public float Speed = 15;

    public float padding = 0.5f;

    public float FiringRate = 0.2f;

    private float playerBoundaryMin;

    private float playerBoundaryMax;

    // Use this for initialization
    void Start ()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        playerBoundaryMin = leftMostPosition.x + padding;
        playerBoundaryMax = rightMostPosition.x - padding;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.01f, FiringRate);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }

    private void Fire()
    {
        GameObject laserbeam = Instantiate(Laser, transform.position, Quaternion.identity) as GameObject;
        laserbeam.GetComponent<Rigidbody2D>().velocity = Vector3.up * Speed;
    }

    private void move(Vector3 RelDirection)
    {
        var newPosition = transform.position + RelDirection * Speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, playerBoundaryMin, playerBoundaryMax), newPosition.y);
    }
}
