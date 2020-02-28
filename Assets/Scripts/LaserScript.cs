using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class LaserScript : MonoBehaviour
{

    public GameObject PlayerExplosion;
    public GameObject AsteroidExplosion;
    public float laserTimeAlive;
    private bool firstCollisionsWithPlayer;
    private GameControllerScript gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        Destroy(gameObject, laserTimeAlive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //Игнорирование первого столкновения с коллижном игрока
            if (!firstCollisionsWithPlayer)
            {
                firstCollisionsWithPlayer = true;
                return;
            }
            else
            {
                gameController.decreaseLife(1);
                Debug.Log("Player has been destroyed");
                Destroy(other.gameObject);
                Instantiate(PlayerExplosion, other.gameObject.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
}