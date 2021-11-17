using System;
using UnityEngine;

public class ClickAndRotate : MonoBehaviour
{
    [SerializeField] private float distanceToTarget = 10;
   
    private Vector3 previousPosition;
    private Camera camera;
    private Transform target;

    private void Awake() => 
        this.camera = this.gameObject.GetComponent<Camera>();

    public void SetTarget(Transform target) => 
        this.target = target;

    void Update()
    {
        if (target == null)
            return;
        
        RotateFromTarget();
    }

    private void RotateFromTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = camera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            camera.transform.position = target.position;

            camera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            camera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis,
                Space.World); // <— This is what makes it work!

            camera.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
    }
}
