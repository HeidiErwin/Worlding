using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public void FadeToWhite(GameObject grandmaToHide, GameObject grandmaToShow) {
        StartCoroutine(FadeWhite(grandmaToHide, grandmaToShow));
    }

    IEnumerator FadeWhite(GameObject grandmaToHide, GameObject grandmaToShow) {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        grandmaToHide.SetActive(false);
        grandmaToShow.SetActive(true);
        yield return new WaitForSeconds(.5f);
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false; // so can't click on buttons you can't see, not really relevant to this
        yield return null;
    }

}
