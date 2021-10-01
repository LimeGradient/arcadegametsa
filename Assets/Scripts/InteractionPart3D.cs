using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPart3D : MonoBehaviour {
    public Collider collider;
    void Start() {
        if (collider == null) {
            if (TryGetComponent(typeof (Collider), out Component collider)) {
                this.collider = (Collider) collider;
            } else {
                Debug.LogError("InteractionPart3D needs a collider attached to the object");
            }
        }

        gameObject.layer = 9;
    }

    public void Interact() {
        Debug.Log("Touch");
    }
}
