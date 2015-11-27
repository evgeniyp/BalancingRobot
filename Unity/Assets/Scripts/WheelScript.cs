using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour
{
    private readonly Vector3 AXIS_Y = new Vector3(0, 1, 0);
    private readonly Vector3 AXIS_Y_ = new Vector3(0, -1, 0);

    private Rigidbody _stickRb;
    private Rigidbody _thisRb;
    private HingeJoint _thisHj;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _thisRb = GetComponent<Rigidbody>();
        _thisHj = GetComponent<HingeJoint>();
        _stickRb = _thisHj.connectedBody;
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        float inputValue = Input.GetAxis("Horizontal");

        _thisHj.axis = inputValue < 0 ? AXIS_Y_ : AXIS_Y;
        JointMotor motor = _thisHj.motor;
        motor.targetVelocity = Mathf.Abs(inputValue) * 2000;
        _thisHj.motor = motor;

        //EngagePid();
    }

    public void Reset()
    {
        _thisRb.velocity = Vector3.zero;
        _thisRb.angularVelocity = Vector3.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;

        pTerm = iTerm = dTerm = 0;
    }


    float pTerm, iTerm, dTerm;
    float KP = 300, KI = 15, KD = 200;

    private float pitch;
    private float last_pitch;

    private void EngagePid()
    {
        pitch = _stickRb.transform.localRotation.z;

        pTerm = KP * pitch;
        iTerm = KI * pitch + iTerm;
        dTerm = KD * (pitch - last_pitch);

        last_pitch = pitch;

        JointMotor motor = _thisHj.motor;
        motor.targetVelocity = pTerm + iTerm + dTerm;
        _thisHj.motor = motor;

        //Debug.Log(_stickRb.transform.localRotation.z);
        //Debug.Log(Vector3.Angle(Vector3.up, _stickRb.transform.transform.up));
    }
}
