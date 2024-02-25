using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEventListener : MonoBehaviour {
    [SerializeField] private FloatEvent _event = default;

    public UnityEvent<float> listener;
    void OnEnable() {
        _event?.Subscribe(Respond);
    }

    void OnDisable() {
        _event?.unSubscribe(Respond);
    }

    void Respond(float value) {
        listener?.Invoke(value);
    }
}