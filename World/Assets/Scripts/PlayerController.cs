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

    //void FixedUpdate() {
    //    if (Input.GetKeyDown(KeyCode.R)) { // roll mode
    //        if (mode == 0) {
    //            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    //            curlyTailMonkey.SetActive(false);
    //            straightTailMonkey.SetActive(true);
    //            straightTailMonkey.transform.rotation = Quaternion.Euler(90, 0, -90);
    //            straightTailMonkey.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .15f, this.transform.position.z);
    //            mode = 1;
    //        } else {
    //            straightTailMonkey.SetActive(false);
    //            curlyTailMonkey.SetActive(true);
    //            mode = 0;
    //        }
    //    }
    //    MovePlayer();
    //}

    //private void MovePlayer() {
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");
    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;
    //    transform.Translate(movement, Space.Self);

    //    if (mode == 0) {
    //    } else {
    //        straightTailMonkey.transform.Rotate(transform.rotation.x, transform.rotation.y + 10.0f, transform.rotation.z);
    //        //rb.AddForce(new Vector3(10.0f, 10.0f, 10.0f) * speed * Time.deltaTime);
    //    }
    //}
}