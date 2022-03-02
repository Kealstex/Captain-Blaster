using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float yLimit = 5f;
    public float reloadTime = 0.5f;

    private float _elapsedTime = 0f;
    
    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime,0);

        var position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) && _elapsedTime > reloadTime)
        {
            SpawnBullet();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            gameManager.curGunMode = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            gameManager.curGunMode = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            gameManager.curGunMode = 3;
    }

    private void SpawnBullet()
    {
        switch (gameManager.curGunMode)
        {
            case 2:
                SecondModeGun();
                break;
            case 3:
                ThirdModeGun();
                break;
            default:
                FirstModeGun();
                break;
        }

        _elapsedTime = 0f;
    }

    private void FirstModeGun()
    {
        var spawnPos = transform.position;
        spawnPos += new Vector3(0, 1.2f, 0);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }

    private void SecondModeGun()
    {
        var spawnPos = transform.position;
        spawnPos += new Vector3(-0.1f, 1.2f, 0);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        spawnPos += new Vector3(0.2f, 0, 0);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }

    private void ThirdModeGun()
    {
        var spawnPos = transform.position;
        spawnPos += new Vector3(-0.1f, 1.2f, 0);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        spawnPos += new Vector3(0.2f, 0, 0);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        spawnPos += new Vector3(-0.4f, 1.2f, 0);
        var leftBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        var bulletSpeed = leftBullet.GetComponent<Bullet>().speed;
        leftBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bulletSpeed);
        spawnPos += new Vector3(0.8f, 0, 0);
        var rightBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        rightBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.PlayerDied();;
    }
}
