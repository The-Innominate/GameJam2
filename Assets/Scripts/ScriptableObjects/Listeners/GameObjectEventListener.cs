using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEventListener : MonoBehaviour {
    [SerializeField] private GameObjectEvent _event = default;

    public UnityEvent<GameObject> listener;
    void OnEnable() {
        _event?.Subscribe(Respond);
    }

    void OnDisable() {
        _event?.unSubscribe(Respond);
    }

    void Respond(GameObject value) {
        listener?.Invoke(value);
    }
}