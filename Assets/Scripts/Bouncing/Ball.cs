using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Ball : MonoBehaviour {
  int score;

  public float ySpeed = 1.0f;

  Rigidbody2D rigidbodyComponent;

  public void Start() {
    score = 0;
    rigidbodyComponent = GetComponent<Rigidbody2D>();
    rigidbodyComponent.velocity = new Vector2(0.0f, ySpeed);
  }

  public void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.layer == 10) { //layer
      Destroy(other.gameObject);
      score++;
    }

    if (other.gameObject.CompareTag("Bouncer")) {
      float xDiff = other.gameObject.transform.position.x - transform.position.x;

      Vector2 newVelocity = new Vector2(-xDiff, -ySpeed);
      rigidbodyComponent.velocity = newVelocity;
    }
  }
}