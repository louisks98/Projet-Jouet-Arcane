using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _cubeNb = 0;
    private int _cylinderNb = 0;
    private int _sphereNb = 0;
    private int _capsuleNb = 0;
    
    public void Create(Vector3 pos, PrimitiveType type)
    {
        GameObject obj = GameObject.CreatePrimitive(type);
        
        switch (type)
        {
            case PrimitiveType.Cube:
                obj.name = "Cube_" + _cubeNb;
                _cubeNb++;
                break;
            case PrimitiveType.Sphere:
                obj.name = "Sphere_" + _sphereNb;
                _sphereNb++;
                break;
            case PrimitiveType.Cylinder:
                obj.name = "Cylinder_" + _cylinderNb;
                _cylinderNb++;
                break;
            case PrimitiveType.Capsule:
                obj.name = "Capsule_" + _capsuleNb;
                _capsuleNb++;
                break;
        }
        obj.AddComponent<CheckCollision>();
        var rb = obj.AddComponent<Rigidbody>();
        rb.useGravity = false;
        obj.transform.position = pos;
    }
}
