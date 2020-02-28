using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float spaceshipTurnSpeed = 360.0f;
    public float spaceshipMaxSpeed = 5.0f;
    public float laserSpeed;
    private float verticalInput;
    private float horizontalInput;
    public GameObject laserPrefab;
    public Transform laserGun;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput != 0)
        {
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, transform.up * verticalInput * spaceshipMaxSpeed, 0.02f);
        }

        rigidbody.AddTorque(-horizontalInput * spaceshipTurnSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(laserPrefab, laserGun.position, laserGun.rotation);
            Rigidbody2D bulletRigidbody = go.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(transform.up * laserSpeed, ForceMode2D.Impulse);
        }
    }

}
