using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    Quaternion originalRotation;
    public GameObject target;
    void Start()
    {
        originalRotation = target.transform.rotation;
    }

    public void Reset()
    {
        target.transform.rotation = originalRotation;
    }
}
