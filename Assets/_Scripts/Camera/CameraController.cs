using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;

    public Vector3 zoomAmount;


    private Vector3 m_NewPosition;
    private Quaternion m_NewRotation;
    private Vector3 m_NewZoom;

    private Vector3 m_DragStartPosition;
    private Vector3 m_DragCurrentPosition;
    private Vector3 m_RotateStartPosition;
    private Vector3 m_RotateCurrentPosition;

    public Vector3 maxZoom;
    public Vector3 minZoom;



    // Start is called before the first frame update
    void Start()
    {
        m_NewPosition = transform.position;
        m_NewRotation = transform.rotation;
        m_NewZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleMovementInput();
        HandleMouseInput();
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_NewPosition += (transform.forward * movementSpeed);
        } 
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_NewPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_NewPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_NewPosition += (transform.right * -movementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            m_NewRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            m_NewRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }


        //if (Input.GetKey(KeyCode.R))
        //{
        //    m_NewZoom += zoomAmount;
        //}
        //if (Input.GetKey(KeyCode.F))
        //{
        //    m_NewZoom -= zoomAmount;
        //}

        //if (m_NewZoom.y > maxZoom.y)
        //{
        //    m_NewZoom = maxZoom;
        //} else if (m_NewZoom.y < minZoom.y)
        //{
        //    m_NewZoom = minZoom;
        //}

        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, m_NewPosition, Time.deltaTime * movementTime), Quaternion.Lerp(transform.rotation, m_NewRotation, Time.deltaTime * movementTime));
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, m_NewZoom, Time.deltaTime * movementTime);
        
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                m_DragStartPosition = ray.GetPoint(entry);
            }

        }
        if (Input.GetMouseButton(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                m_DragCurrentPosition = ray.GetPoint(entry);

                m_NewPosition = transform.position + m_DragStartPosition - m_DragCurrentPosition;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            m_RotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            m_RotateCurrentPosition = Input.mousePosition;

            Vector3 difference = m_RotateStartPosition - m_RotateCurrentPosition;

            m_RotateStartPosition = m_RotateCurrentPosition;

            m_NewRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            m_NewZoom += Input.mouseScrollDelta.y * zoomAmount;
            if (m_NewZoom.y > maxZoom.y)
            {
                m_NewZoom = maxZoom;
            }
            else if (m_NewZoom.y < minZoom.y)
            {
                m_NewZoom = minZoom;
            }
        }
    }
}
