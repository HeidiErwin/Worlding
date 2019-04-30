using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grandma : MonoBehaviour
{
    [SerializeField] private GameObject textbox;
    [SerializeField] private GameObject textboxImage;
    [SerializeField] private GameController controller;
    private bool dialogueShown = false;
    private bool soundPlayed = false;
    private bool readyToVanish = false;

    private AudioSource source;
    public AudioClip foundSound;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (!soundPlayed) {
            source.PlayOneShot(foundSound, 0.5f);
            soundPlayed = true;
        }
    }

    private void OnTriggerStay(Collider other) {
        textbox.GetComponent<Text>().text = this.GetComponent<Text>().text;
        if(!dialogueShown) {
            textbox.SetActive(true);
            textboxImage.SetActive(true);
            dialogueShown = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (!readyToVanish) {
            textbox.GetComponent<Text>().text = "";
            textbox.SetActive(false);
            textboxImage.SetActive(false);
            controller.StartCoroutine(controller.MoveGrandma());
            readyToVanish = true;
        }
    }
}
