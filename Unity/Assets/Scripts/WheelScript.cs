using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour
{
    private readonly Vector3 AXIS_Y = new Vector3(0, 1, 0);
    private readonly Vector3 AXIS_Y_ = new Vector3(0, -1, 0);

    private Rigidbody _rb;
    private HingeJoint _hj;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _hj = GetComponent<HingeJoint>();
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        float inputValue = Input.GetAxis("Horizontal");

        _hj.axis = inputValue < 0 ? AXIS_Y_ : AXIS_Y;
        JointMotor motor = _hj.motor;
        motor.targetVelocity = Mathf.Abs(inputValue) * 200;
        _hj.motor = motor;
    }

    public void Reset()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}
