using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start() {
        offset = transform.position - player.transform.position;
    }

    // After 'Update()', just before each frame rendered
    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}