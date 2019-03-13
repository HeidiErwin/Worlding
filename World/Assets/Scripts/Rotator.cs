using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    [SerializeField] private float rotationSpeed; 

    void Update() {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * rotationSpeed);
    }
}