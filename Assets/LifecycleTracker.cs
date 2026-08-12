using UnityEngine;

public class LifecycleTracker : MonoBehaviour
{
    void Awake() => Debug.Log("Awake");
    void OnEnable() => Debug.Log("OnEnable");
    void Start() => Debug.Log("Start");
    void FixedUpdate() => Debug.Log("FixedUpdate");
    void Update() => Debug.Log("Update");
    void LateUpdate() => Debug.Log("LateUpdate");
    void OnDisable() => Debug.Log("OnDisable");
    void OnDestroy() => Debug.Log("OnDestroy");
}