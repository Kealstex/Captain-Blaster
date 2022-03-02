using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public bool isDiagonal = false;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        var rigidBody2D = GetComponent<Rigidbody2D>();
        
        if (!isDiagonal)
            rigidBody2D.velocity = new Vector2(0f, speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        Debug.Log("Bullet collision");
        gameManager.AddScore();
        Destroy(gameObject);
    }
}
