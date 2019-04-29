using UnityEngine;
using System.Collections;

public class JasmineRotate : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    [SerializeField] private int heightCounter;
    private float height = .5f;
    private int counter = 0;

    void Update() {
        if (counter < heightCounter) {
            transform.Translate(new Vector3(0, height, 0) * Time.deltaTime * rotationSpeed);
            counter++;
        } else {
            counter = 0;
            height *= -1;
        }
    }
}