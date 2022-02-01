using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ObjectActions : MonoBehaviour
{
    private Camera _camera;
    private float _z;
    private Vector3 _offset;
    private bool _dragging;
    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _camera = Camera.main;
        _z = _camera.WorldToScreenPoint(transform.position).z;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _z);
            transform.position = _camera.ScreenToWorldPoint(position + new Vector3(_offset.x, _offset.y));
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnMouseDown()
    {
        if (!_dragging)
        {
            BeginDrag();
        }
    }

    private void OnMouseUp()
    {
        EndDrag();
    }

    private void BeginDrag()
    {
        _dragging = true;
        _offset = _camera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    private void EndDrag()
    {
        _dragging = false;
    }

    private void OnMouseUpAsButton()
    {
        var panel = SceneManager.GetActiveScene().GetRootGameObjects().Select(x => x.GetComponent<PanelInfo>())
            .ToList();
        var renderer = GetComponent<Renderer>();
        panel[5].ShowPanel();
        panel[5].SetInfo(gameObject, transform.localScale, renderer.material.color);
    }
}
