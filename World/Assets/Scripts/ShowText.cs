using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] private GameObject textbox;
    [SerializeField] private GameObject textboxImage;

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
        textbox.SetActive(true);
        textboxImage.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        textbox.GetComponent<Text>().text = "";
        textbox.SetActive(false);
        textboxImage.SetActive(false);
    }
}
