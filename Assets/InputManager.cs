using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Camera _camera;
    private Spawner _spawner;
    private PrimitiveType _primitiveType;
    private bool _inSelection;
    void Start()
    {
        _camera = Camera.main;
        _spawner = FindObjectOfType<Spawner>();
        _primitiveType = PrimitiveType.Cube;
        _inSelection = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _inSelection = false;
            _primitiveType = PrimitiveType.Cube;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inSelection = false;
            _primitiveType = PrimitiveType.Sphere;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            _inSelection = false;
            _primitiveType = PrimitiveType.Cylinder;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _inSelection = false;
            _primitiveType = PrimitiveType.Capsule;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _inSelection = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!_inSelection)
            {
                var pos = Input.mousePosition;
                pos.z = _camera.nearClipPlane + 7;
                _spawner.Create(_camera.ScreenToWorldPoint(pos), _primitiveType);
            }
            
        }
    }
}
