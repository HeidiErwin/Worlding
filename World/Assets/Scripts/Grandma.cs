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

    private AudioSource source;
    public AudioClip foundSound;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        source.PlayOneShot(foundSound, 0.5f);
    }

    private void OnTriggerStay(Collider other) {
        textbox.GetComponent<Text>().text = this.GetComponent<Text>().text;
        if(!dialogueShown) {
            textbox.SetActive(true);
            textboxImage.SetActive(true);
            dialogueShown = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        textbox.GetComponent<Text>().text = "";
        textbox.SetActive(false);
        textboxImage.SetActive(false);
        controller.StartCoroutine(controller.MoveGrandma());
    }
}
