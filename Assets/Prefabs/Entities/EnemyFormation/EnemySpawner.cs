using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float Width = 10f;
    public float Height = 5f;

    public float Speed = 2f;

    private float formationBoundaryMin;
    private float formationBoundaryMax;

    private bool ltr;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;

            var distance = transform.position.z - Camera.main.transform.position.z;
            var leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
            var rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
            formationBoundaryMin = leftMostPosition.x + Width / 2;
            formationBoundaryMax = rightMostPosition.x - Width / 2;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    // Update is called once per frame
    void Update ()
    {
        if (ltr)
        {
            move(Vector3.right);
        }
        else
        {
            move(Vector3.left);
        }
    }

    private void move(Vector3 RelDirection)
    {
        var newPosition = transform.position + RelDirection * Speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, formationBoundaryMin, formationBoundaryMax), newPosition.y);

        if (newPosition.x <= formationBoundaryMin)
        {
            ltr = true;
        }
        if (newPosition.x >= formationBoundaryMax)
        {
            ltr = false;
        }
    }
}
