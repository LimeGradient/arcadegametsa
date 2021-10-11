using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BrickObject : MonoBehaviour {
  public float x;
  public float y;

  public void Start() {
  }

  void OnDestroy() {
    GameController.bricksLeft--;
  }
}