using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    public int mode = 0; // 0 for normal tail, 1 for straight tail
    public GameObject straightTailMonkey;
    public GameObject curlyTailMonkey;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) { // roll mode
            if (mode == 0) {
                //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                curlyTailMonkey.SetActive(false);
                straightTailMonkey.SetActive(true);
                straightTailMonkey.transform.rotation = Quaternion.Euler(90, 0, -90);
                straightTailMonkey.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .15f, this.transform.position.z);
                mode = 1;
            } else {
                straightTailMonkey.SetActive(false);
                curlyTailMonkey.SetActive(true);
                mode = 0;
            }
        }
        MovePlayer();
    }

    private void MovePlayer() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (mode == 0) {
        } else {
            straightTailMonkey.transform.Rotate(transform.rotation.x, transform.rotation.y + 10.0f, transform.rotation.z);
            //rb.AddForce(new Vector3(10.0f, 10.0f, 10.0f) * speed * Time.deltaTime);
        }
    }
}