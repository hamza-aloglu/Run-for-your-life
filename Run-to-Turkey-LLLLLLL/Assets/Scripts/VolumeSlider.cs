using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    AudioSource gameplaySounds;
    AudioSource menuSound;
    AudioSource explosionSounds;
    AudioSource missile_groundExplosionSound;

    PlayerController playerController;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        gameplaySounds = GameObject.Find("Background").GetComponent<AudioSource>();
        menuSound = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        explosionSounds = GameObject.Find("Player").GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        missile_groundExplosionSound = GameObject.Find("Ground").GetComponent<AudioSource>();

        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.IsGameStarted())
            slider.gameObject.SetActive(false);

        gameplaySounds.volume = slider.value;
        menuSound.volume = slider.value;
        explosionSounds.volume = slider.value;
        missile_groundExplosionSound.volume = slider.value;
    }
}
