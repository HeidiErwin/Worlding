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

    public IEnumerator MoveGrandma() {
        fadePanel.GetComponent<Fade>().FadeToWhite(grandmas[currentGrandma], grandmas[currentGrandma +1]);
        yield return new WaitForSeconds(1);
        currentGrandma++;
    }
}
