using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    private GameObject _stick;
    private GameObject _smoothTarget;

    public float FlowSpeed = 0.03f;

    private void Start()
    {
        _stick = GameObject.Find("Stick");

        _smoothTarget = new GameObject();
        _smoothTarget.transform.position = _stick.transform.position;
    }

    public void Reset()
    {
        _smoothTarget.transform.position = _stick.transform.position;
    }

    private void Update()
    {
        _smoothTarget.transform.position = Vector3.Lerp(_smoothTarget.transform.position, _stick.transform.position, FlowSpeed);
        transform.LookAt(_smoothTarget.transform);
    }
}
