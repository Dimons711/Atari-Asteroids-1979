using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
public float RotationSpeed;
public float minSpeed, maxSpeed;
public GameObject AsteroidExplosion;
public GameObject PlayerExplosion;

    public GameObject AsteroidMed;
    public GameObject AsteroidSmall;

    public GameControllerScript gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        Rigidbody2D asteroid = GetComponent<Rigidbody2D>();
        asteroid.angularVelocity = Random.Range(-RotationSpeed, RotationSpeed) ;
        if (asteroid.position.y < 0)
        {
            asteroid.velocity = new Vector2(Random.Range(-70, 70), 100) / 100 * Random.Range(minSpeed, maxSpeed);
        } else
        {
            asteroid.velocity = new Vector2(Random.Range(-70, 70), -100) / 100 * Random.Range(minSpeed, maxSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{

        if (other.gameObject.tag =="Asteroid Big" || other.gameObject.tag == "Asteroid Med" || other.gameObject.tag == "Asteroid Small")
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has been destroyed");
            gameController.decreaseLife(1);
            Instantiate(PlayerExplosion, other.gameObject.transform.position, Quaternion.identity);
        }

        else
        {
            if(this.gameObject.tag == "Asteroid Big")

            {
                gameController.increaseScore(40);
                Instantiate(AsteroidMed, other.gameObject.transform.position, Quaternion.identity);
                Instantiate(AsteroidMed, other.gameObject.transform.position, Quaternion.identity);
            }

            if (this.gameObject.tag == "Asteroid Med")

            {
                gameController.increaseScore(15);
                Instantiate(AsteroidSmall, other.gameObject.transform.position, Quaternion.identity);
                Instantiate(AsteroidSmall, other.gameObject.transform.position, Quaternion.identity);

            }

            gameController.increaseScore(10);

        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(AsteroidExplosion, other.gameObject.transform.position, Quaternion.identity);

    }
}
