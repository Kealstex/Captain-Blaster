using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public float speed = -2f;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(0, speed);
    }
}
