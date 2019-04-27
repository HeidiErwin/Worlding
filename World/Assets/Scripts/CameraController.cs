using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField] private Vector3 offset; // 0, .4, -1
    public Transform target;// player
    [SerializeField] private float currentZoom; // 1.2
    [SerializeField] private float zoomSpeed; // 4
    [SerializeField] private float minZoom; // 1.2
    [SerializeField] private float maxZoom; // 5

    [SerializeField] private float pitch; //.4
    [SerializeField] private float yawSpeed = 100f; //100

    private float currentYaw = 0f; //for camera rotation

    private void Update() {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    private void LateUpdate() {
        transform.position = target.position + offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

}