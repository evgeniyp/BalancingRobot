using UnityEngine;
using System.Collections;

public class StickScript : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public void Reset()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}
