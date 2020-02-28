using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject[] asteroid;
    public float minDelay, maxDelay;
    private float nextLaunchUp;
    private float nextLaunchDown;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "AsteroidEmitterDown")
        {


            if (Time.time > nextLaunchDown)

            {
            float xPos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float yPos = transform.position.y;
            Instantiate(asteroid[Random.Range(0, asteroid.Length)], new Vector2(xPos, yPos), Quaternion.identity);
            nextLaunchDown = Time.time + Random.Range(minDelay, maxDelay);
            }
        }
        else
        {
            if (Time.time > nextLaunchUp)

            {
                float xPos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                float yPos = transform.position.y;
                Instantiate(asteroid[Random.Range(0, asteroid.Length)], new Vector2(xPos, yPos), Quaternion.identity);
                nextLaunchUp = Time.time + Random.Range(minDelay, maxDelay);
            }
        }
    }
}
