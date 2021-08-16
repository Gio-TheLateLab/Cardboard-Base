using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Based on the script Google Camera Pointer
// Allows the user to create events when an object is seen or selected by
// the player
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

namespace Gio {
    public class CustomCameraPointer : MonoBehaviour {

        static CustomCameraPointer instance = null;
        public static CustomCameraPointer Instance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<CustomCameraPointer>();
                }
                return instance;
            }
        }

        private const float maxDistance = 10;
        TriggerEvent trigger = null;

        void Awake() {
            if (instance == null) {
                instance = this;
            }
        }

        void Update() {

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance)) {

                TriggerEvent trigger = hit.transform.GetComponent<TriggerEvent>();
                if (trigger != null && trigger != this.trigger) {
                    this.trigger?.PointerExit();
                    this.trigger = trigger;
                    trigger.PointerEnter();
                }

                if (trigger == null) {
                    this.trigger?.PointerExit();
                    this.trigger = null;
                }


            } else {
                // No GameObject detected in front of the camera.
                trigger?.PointerExit();
                trigger = null;
            }

            // Checks for screen touches.
            if (Google.XR.Cardboard.Api.IsTriggerPressed) {
                trigger.PointerDown();
            }
        }
    }
}