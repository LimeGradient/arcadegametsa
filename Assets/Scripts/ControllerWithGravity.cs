﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerWithGravity : MonoBehaviour {

  public Rigidbody2D rigidbody2DObject;
  float horizontal;
  bool shouldJumpNext;

  public Vector2 raycastPointStart;
  public Vector2 raycastPointEnd;
  public int raycastPoints;

  public float groundDist = 1.0f;

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
      if (isGrounded()) {
        newForce.y += jumpForce;
      }
      shouldJumpNext = false;
    }

    rigidbody2DObject.AddForce(newForce * speed);
  }

  bool isGrounded() {
    RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(raycastPointStart.x, raycastPointStart.y), transform.position + new Vector3(raycastPointEnd.x, raycastPointEnd.y) + new Vector3(0, -groundDist), 0, Vector2.down, 0.01f,
    LayerMask.GetMask("ground"), groundDist);

    if (hit != null) {
      return true;
    }
    return false;
  }
}