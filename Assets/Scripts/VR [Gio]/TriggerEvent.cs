using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gio {
    public class TriggerEvent : MonoBehaviour {

        [SerializeField] UnityEvent OnPointerEnter;
        [SerializeField] UnityEvent OnPointerDown;
        [SerializeField] UnityEvent OnPointerUp;

        [SerializeField] Gradient gradient;
        [SerializeField] float duration = 3f;

        ParticleSystem ps;
        ParticleSystem.MainModule main;

        int state = 0;
        float t1 = 0, t2 = 0;

        void Awake() {
            ps = GetComponentInChildren<ParticleSystem>();
            main = ps.main;
            main.startColor = new ParticleSystem.MinMaxGradient(gradient);
            main.simulationSpeed = 3f / duration;
        }

        void Update() {

            if (state == 1) {
                if (t1 >= duration) {
                    PointerDown();
                    t1 = 0;
                    state = 2;
                }
                t1 += Time.deltaTime;
            }

            if (state == 3) {
                t2 += Time.deltaTime;
                if (t2 >= duration) {
                    ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    t1 = 0;
                    t2 = 0;
                    state = 0;
                }
            }
        }

        public void PointerEnter() {
            if (state == 0 || state == 3) {
                transform.LookAt(CustomCameraPointer.Instance.transform);
                print("Pointer enter");
                OnPointerEnter.Invoke();
                ps.Play();

                t2 = 0;
                state = 1;
            }
        }

        public void PointerDown() {
            print("Pointer down");
            OnPointerDown.Invoke();
        }

        public void PointerExit() {
            print("Pointer exit");
            OnPointerUp.Invoke();

            if (state == 1) { // Wait for a few seconds before clear the timer
                ps.Pause();
                state = 3;
            } else {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                state = 0;
            }
        }
    }
}