using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop2 : MonoBehaviour
{
    [System.NonSerialized] public GameObject pickedUpObject;
    [System.NonSerialized] public Transform pickupSlot;
    [System.NonSerialized] public bool spiceHeld;
    private SoundFXManager soundManager;
    void Start()
    {
        pickupSlot = transform.GetChild(0).GetChild(0);
        soundManager = SoundFXManager.instance;
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
        pickedUpObject.layer = LayerMask.NameToLayer("RigidbodyIngredient");
        pickedUpObject = null;
        spiceHeld = false;
    }
    public void PickUp(GameObject go)
    {
        if (pickedUpObject != null) return;
        soundManager.PlaySoundFX(go.GetComponent<SoundFX>().GetAudioClip());
        pickedUpObject = go;
        Destroy(pickedUpObject.GetComponent<Rigidbody>());
        go.transform.SetParent(pickupSlot);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.Euler(-90,0,0);
        go.layer = LayerMask.NameToLayer("Ignore Raycast");
        if (go.TryGetComponent(out SpiceBehaviour sb))
        {
            spiceHeld = true;
        }
    }
}
