using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public int Damage = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit()
    {
        Destroy(gameObject);
    }
}
