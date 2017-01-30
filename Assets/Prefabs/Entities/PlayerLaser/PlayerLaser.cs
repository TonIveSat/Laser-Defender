using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public float Speed = 15f;

    private float topMostPosition;

    // Use this for initialization
    void Start ()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        topMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y;
    }

    // Update is called once per frame
    void Update ()
    {
        move(Vector3.up);
	}

    private void move(Vector3 RelDirection)
    {
        var newPosition = transform.position + RelDirection * Speed * Time.deltaTime;
        transform.position = newPosition;

        if (newPosition.y > topMostPosition)
        {
            GameObject.Destroy(this);
        }
    }
}
