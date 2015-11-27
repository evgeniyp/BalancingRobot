using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelScript : MonoBehaviour
{
    private readonly Vector3 AXIS_Y = new Vector3(0, 1, 0);
    private readonly Vector3 AXIS_Y_ = new Vector3(0, -1, 0);

    private Rigidbody _stickRb;
    private Rigidbody _thisRb;
    private HingeJoint _thisHj;

    public GameObject pSlider;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    float pTerm, iTerm, dTerm;
    public float KP = 1000, KI = 100, KD = 2500;

    private float pitch;
    private float last_pitch;

    private void Start()
    {
        _thisRb = GetComponent<Rigidbody>();
        _thisHj = GetComponent<HingeJoint>();
        _stickRb = _thisHj.connectedBody;
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        pSlider.GetComponent<Slider>().value = KP;
    }

    private void FixedUpdate()
    {
        float inputValue = Input.GetAxis("Horizontal");
        float userVelocity = inputValue * 2000;
        EngagePid(userVelocity);
    }

    public void Reset()
    {
        _thisRb.velocity = Vector3.zero;
        _thisRb.angularVelocity = Vector3.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;

        pTerm = iTerm = dTerm = 0;
    }

    private void EngagePid(float velocity)
    {
        pitch = _stickRb.transform.localRotation.z;

        pTerm = KP * pitch;
        iTerm = KI * pitch + iTerm;
        dTerm = KD * (pitch - last_pitch);

        last_pitch = pitch;

        JointMotor motor = _thisHj.motor;
        motor.targetVelocity = velocity + pTerm + iTerm + dTerm;
        _thisHj.motor = motor;
    }

    public void SetP(float value)
    {
        KP = value;
    }

    public void SetI(float value)
    {
        KI = value;
    }

    public void SetD(float value)
    {
        KD = value;
    }
}
