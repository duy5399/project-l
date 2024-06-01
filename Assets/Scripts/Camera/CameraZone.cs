using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GameManager.instance.virtualCamera.GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")){
            return;
        }
        switch (this.gameObject.name)
        {
            case "Tarvern_Mia_CameraZone1":
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.2f;
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.6f;
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 5;
                break;
            case "Tarvern_Mia_CameraZone2":
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.8f;
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.6f;
                virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 5;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;
        virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
        virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 15;
    }
}
