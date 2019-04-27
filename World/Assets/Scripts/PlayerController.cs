using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    Camera cam;

    [SerializeField] private LayerMask movementMask; // ensures no hit unless tagged Ground (mask dragged in in inspector)
    private Rigidbody rb;
    PlayerMotor motor;

    void Start() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) { // left mouse button
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                // move our player to what we hit
                motor.MoveToPoint(hit.point);
                Debug.Log("ground hit");
            }
        }
    }
}