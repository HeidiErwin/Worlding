using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int currentGrandma = 0;
    [SerializeField] GameObject[] grandmas;
    private GameObject fadePanel;
    [SerializeField] GameObject grandpa;
    [SerializeField] GameObject table;

    public void Awake() {
        fadePanel = GameObject.Find("FadePanel");
    }

    public IEnumerator MoveGrandma() {
        if (currentGrandma == (grandmas.Length - 2)) {
            table.GetComponent<SphereCollider>().enabled = false;
            grandpa.GetComponent<Text>().text = "the garden is more beautiful than it looks at first. if you can't see it, keep looking.";
        }
        fadePanel.GetComponent<Fade>().FadeToWhite(grandmas[currentGrandma], grandmas[currentGrandma +1]);
        yield return new WaitForSeconds(1);
        currentGrandma++;
    }
}
