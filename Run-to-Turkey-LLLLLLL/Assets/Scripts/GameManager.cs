using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController; //

    private float score = 0;
    private int health = 5;
    private float gameTime = 0;

    public TextMeshProUGUI title;
    public TextMeshProUGUI deadText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI levelUpText;

    public Button startButton;
    public Button restartButton;

    AudioSource Sounds;
    public AudioClip levelUpSound;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Sounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.SetText("Score: " + (int)score);
        livesText.SetText("Lives: " + health);
        if (playerController.IsGameStarted())
        {
            gameTime += Time.deltaTime;
            title.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            Sounds.Stop();
            if (!playerController.IsGameOver())
                score += Time.deltaTime;
        }

        if (playerController.IsGameOver())
        {
            deadText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

        if (gameTime > 32 && gameTime < 37 && !playerController.IsGameOver())
        {
            levelUpText.gameObject.SetActive(true);
            Sounds.PlayOneShot(levelUpSound);
        }
        if (gameTime > 37)
        {
            levelUpText.gameObject.SetActive(false);
        }
    }

    public void AddHealth(int amount)
    {
        health += amount;
        System.Console.WriteLine("Health: " + health);
    }

    public int DisplayHealth()
    {
        return health;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



