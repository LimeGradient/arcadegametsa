
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MuseumController : MonoBehaviour {

  public Rigidbody2D rigidbody2DObject;
  float horizontal;
  bool shouldJumpNext;
  public float gravity = 1.0f;
  public float speed = 2.0f;
  public float jumpForce = 5.0f;
  public void Start() {
    if (GetComponent<Rigidbody2D>()) {
      rigidbody2DObject = GetComponent<Rigidbody2D>();
    }

    shouldJumpNext = false;
  }

  public void Update() {
    horizontal = Input.GetAxis("Horizontal");

    if (!shouldJumpNext) {
      shouldJumpNext = Input.GetButtonDown("Jump");
    }
  }

  public void FixedUpdate() {
    Vector2 newForce = new Vector2(horizontal, -gravity);

    if (shouldJumpNext) {
      if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("ground"))) {
        newForce.y += jumpForce;
      }
      shouldJumpNext = false;
    }

    rigidbody2DObject.AddForce(newForce * speed);
  }
}