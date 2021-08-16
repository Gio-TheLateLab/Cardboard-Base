using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {

    new Rigidbody rigidbody;
    new Camera camera;

    int jumps = 1;
    [SerializeField] float speed = 3, jumpForce = 500;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update() {

        Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
        transform.position += velocity * Time.deltaTime;

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }

    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }
}
