using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class VoidEventListener : MonoBehaviour {
    [SerializeField] private VoidEvent _event = default;

    public UnityEvent listener;
    void OnEnable() {
        _event?.Subscribe(Respond);
    }

    void OnDisable() {
        _event?.unSubscribe(Respond);
    }

    void Respond() {
        listener?.Invoke();
    }
}