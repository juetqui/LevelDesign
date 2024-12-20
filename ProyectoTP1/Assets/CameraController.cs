using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private bool _freezeCameraPosition = false;

    private Vector3 _positionToFreezeCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_freezeCameraPosition)
        {
            _cameraTransform.position = _positionToFreezeCamera;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_freezeCameraPosition)
        {
            _freezeCameraPosition = true;
            _positionToFreezeCamera = _cameraTransform.position;
        }
        else _freezeCameraPosition = false;
    }
}
