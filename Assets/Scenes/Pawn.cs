using UnityEngine;

public class Pawn: MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;

    [Header("Movement Settings")]
    public float thrust = 1.0f;
    public float drag = 2.0f;
    public float angularDrag = 5.0f;
    public float rollSpeed = 1.0f;

    [Header("Zoom Settings")]
    [Range(10, 100)]
    public float fastLevel = 60f;
    public float fastSpeed = 5f;

    private float defaultDrag;
    private float defaultAngularDrag;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        defaultDrag = rb.linearDamping;
        defaultAngularDrag = rb.angularDamping;
        cam.fieldOfView = fastLevel;
    }

    void Update()
    {
        HandleSpeedUp();
    }




    public void ApplyDrag()
    {
        rb.linearDamping = drag;
        rb.angularDamping = angularDrag;
    }

    public void ResetDrag()
    {
        rb.linearDamping = defaultDrag;
        rb.angularDamping = defaultAngularDrag;
    }

    public void HandleRollLeft()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rollSpeed * Time.deltaTime);
    }

    public void HandleRollRight()
    {
        transform.rotation *= Quaternion.Euler(0, 0, -rollSpeed * Time.deltaTime);
    }

    private void HandleSpeedUp()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        fastLevel -= scrollInput * fastSpeed;
        fastLevel = Mathf.Clamp(fastLevel, 10f, 100f);
        cam.fieldOfView = fastLevel;
    }
}
