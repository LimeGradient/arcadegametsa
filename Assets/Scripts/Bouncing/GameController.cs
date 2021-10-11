using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  public static int bricksLeft = 1000;

  public float xSpeed = 1.0f;

  float xMovement;

  public void Start() {
    xMovement = 0.0f;
  }

  public void Update() {
    xMovement = Input.GetAxis("Horizontal");
  }

  public void LateUpdate() {
    transform.position += new Vector3(xMovement * xSpeed * Time.fixedDeltaTime, 0);
  }
}