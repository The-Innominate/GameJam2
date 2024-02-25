using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour {
    [SerializeField] private IntEvent _event = default;

    public UnityEvent<int> listener;
    void OnEnable() {
        _event?.Subscribe(Respond);
    }

    void OnDisable() {
        _event?.unSubscribe(Respond);
    }

    void Respond(int value) {
        listener?.Invoke(value);
    }
}