using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
    public void QuitGame() {
        Application.Quit();
    }

    public void BackToTitle() {
        SceneManager.LoadScene("Title");
    }

    public void StartGame() {
        SceneManager.LoadScene("Backyard");
    }

    public void ShowCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().name == "Backyard") {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
