using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPart3D : MonoBehaviour {
  public Collider colliderTrigger;

  public Material highlightMaterial;

  private bool highlighted;
  void Start() {
    if (colliderTrigger == null) {
      if (TryGetComponent(typeof(Collider), out Component colliderTrigger)) {
        this.colliderTrigger = (Collider)colliderTrigger;
      }
      else {
        Debug.LogError("InteractionPart3D needs a collider attached to the object");
      }
    }

    gameObject.layer = 9;


    List<Material> materials = new List<Material>();
    GetComponent<MeshRenderer>().GetMaterials(materials);

    highlighted = false;

    foreach (Material mat in materials) {
      if (mat.name.Contains("Highlight")) {
        highlighted = true;
      }
    }
  }

  public void Interact() {
    Debug.Log("Touch");
  }

  public void SetHighlighted(bool highlighted) {
    if (highlighted == this.highlighted) {
      List<Material> materials = new List<Material>();
      GetComponent<MeshRenderer>().GetMaterials(materials);

      bool isHighlighted = false;

      foreach (Material mat in materials) {
        if (mat.name.Contains("Highlight")) {
          isHighlighted = true;
        }
      }

      if (isHighlighted != highlighted) {
        if (highlighted) {
          List<Material> newMats = new List<Material>(GetComponent<MeshRenderer>().materials);
          newMats.Add(highlightMaterial);
          GetComponent<MeshRenderer>().materials = newMats.ToArray();
        }
        else {
          foreach (Material mat in GetComponent<MeshRenderer>().materials) {
            if (mat.name.Contains("Highlighted")) {
              Destroy(mat);
            }
          }
        }
      }
      this.highlighted = highlighted;
    }
  }
}
