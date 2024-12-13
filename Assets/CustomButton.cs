using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    enum axis
    {
        x, y, z
    }
    [SerializeField] axis Sumbu;

    enum cw
    {
        cw,ccw
    }
    [SerializeField] cw Arah;

    public bool buttonPressed;
    private int modifier = 0;
    public GameObject target;
    public float rotationSpeed = 1.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    private void Update()
    {
        if(buttonPressed)
        {
            //ini cmn ganti value
            if (Arah == cw.cw)
            {
                modifier = 1;
            }
            else if (Arah == cw.ccw)
            {
                modifier = -1;
            }

            //bikin ini yg transform
            if (Sumbu == axis.x)
            {
                target.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * modifier);
            }
            else if (Sumbu == axis.y)
            {
                target.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * modifier);
            }
            else if (Sumbu == axis.z)
            {
                target.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * modifier);
            }
        }
    }
}

