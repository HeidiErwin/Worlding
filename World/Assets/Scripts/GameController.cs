using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int currentGrandma = 0;
    [SerializeField] GameObject[] grandmas;
    private GameObject fadePanel;

    public void Awake() {
        fadePanel = GameObject.Find("FadePanel");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine(MoveGrandma());
        }
    }

    public IEnumerator MoveGrandma() {
        fadePanel.GetComponent<Fade>().FadeToWhite(grandmas[currentGrandma], grandmas[currentGrandma +1]);
        yield return new WaitForSeconds(1);
        //grandmas[currentGrandma].SetActive(false);
        currentGrandma++;
        //grandmas[currentGrandma].SetActive(true);
        //fadePanel.GetComponent<Fade>().FadeToTransparent();
    }
}
