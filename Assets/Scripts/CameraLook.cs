
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CinemachineFreeLook))]

public class CameraLook : MonoBehaviour
{
    private CinemachineFreeLook cinemachine;
    private Tut tut;
    [SerializeField]
    private float lookSpeed=1;

    private void Awake()
    {
        tut = new Tut();
       cinemachine=GetComponent<CinemachineFreeLook>();
    }
    private void OnEnable()
    {
        tut.Enable();
    }

    private void OnDisable()
    {
        tut.Disable();
    }
    

    void Update()
    {
        Vector2 delta = tut.Player.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x *200* lookSpeed * Time.deltaTime;
        cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }
}
