using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int Damage = 10;

    // Use this for initialization
    void Start ()
    {
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Hit()
    {
        Destroy(gameObject);
    }
}
