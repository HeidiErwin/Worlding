using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //public GameObject player;
    private Vector3 offset;

    float rotationSpeed = 1;
    public Transform target, player;
    float mouseX, mouseY;

    public Transform obstruction;
    float zoomSpeed = 2f;

    //void Start() {
    //    offset = transform.position - player.transform.position;
    //}

   // After 'Update()', just before each frame rendered
    //void LateUpdate() {
    //    transform.position = player.transform.position + offset;
    //}

    void Start() {
        obstruction = target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate() {
        CamControl();
        //ViewObstructed();
    }


    void CamControl() {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        if (Input.GetKey(KeyCode.LeftShift)) { // can rotate only camera if hold down left shift
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        } else {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }


    void ViewObstructed() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f)) {
            if (hit.collider.gameObject.tag != "Player") {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, target.position) >= 1.5f)
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            } else {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, target.position) < 4.5f)
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }

}