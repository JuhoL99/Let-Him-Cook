using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop2 : MonoBehaviour
{
    [System.NonSerialized] public GameObject pickedUpObject;
    [System.NonSerialized] public Transform pickupSlot;
    void Start()
    {
        pickupSlot = transform.GetChild(0).GetChild(0);
    }

    void Update()
    {
        DropInput();
    }
    void DropInput()
    {
        if (!Input.GetKeyDown(KeyCode.F) || pickedUpObject == null) return;
        pickedUpObject.AddComponent<Rigidbody>();
        pickedUpObject.transform.SetParent(null);
        pickedUpObject.layer = LayerMask.NameToLayer("Default");
        pickedUpObject = null;
    }
    public void PickUp(GameObject go)
    {
        if (pickedUpObject != null) return;
        pickedUpObject = go;
        Destroy(pickedUpObject.GetComponent<Rigidbody>());
        go.transform.SetParent(pickupSlot);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}
