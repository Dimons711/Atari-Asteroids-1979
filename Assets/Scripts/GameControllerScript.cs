using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject lifeText;
    public GameObject Player;
    public GameObject GameOverScreen;

    public float playerLifes;

    private int score = 0;

    void Start()
    {
        lifeText.GetComponent<UnityEngine.UI.Text>().text = "Lifes: " + playerLifes;
    }

    public void increaseScore(int increment)
    {
        score += increment;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }

    public void decreaseLife(int decrement)
    {
        playerLifes -= decrement;
        lifeText.GetComponent<UnityEngine.UI.Text>().text = "Lifes: " + playerLifes;
        if (playerLifes >= 1)
        {
            Instantiate(Player, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            GameObject[] emitters = GameObject.FindGameObjectsWithTag("AsteroidEmitter");
            foreach (GameObject emitter in emitters)
            {
                emitter.SetActive(false);
                GameOverScreen.SetActive(true);
            }
        }
        destroyAsteroids();

    }

    public void destroyAsteroids()
    {
        GameObject[] asteroidsBig = GameObject.FindGameObjectsWithTag("Asteroid Big");
        foreach (GameObject asteroid in asteroidsBig)
        {
            Destroy(asteroid);
        }

        GameObject[] asteroidsMed = GameObject.FindGameObjectsWithTag("Asteroid Med");
        foreach (GameObject asteroid in asteroidsMed)
        {
            Destroy(asteroid);
        }

        GameObject[] asteroidsSmall = GameObject.FindGameObjectsWithTag("Asteroid Small");
        foreach (GameObject asteroid in asteroidsSmall)
        {
            Destroy(asteroid);
        }

        GameObject[] lasers = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject laser in lasers)
        {
            Destroy(laser);
        }

    }
}
