using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerWithoutGravity : MonoBehaviour{

  public float speed = 1.0f;

  public void Update() {
    Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    gameObject.transform.position += new Vector3(movement.x, movement.y) * speed;
  }
}