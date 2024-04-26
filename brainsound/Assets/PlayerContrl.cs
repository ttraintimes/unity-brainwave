using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//Souce: https://stackoverflow.com/questions/62391105/how-to-add-jump-in-c-sharp-script-in-unity3d-using-character-controller
//Souce: https://github.com/fiqryq/Unity-Switch-Camera/blob/main/switchViewCam.cs


    public class PlayerContrl : MonoBehaviour {

    [SerializeField]
    Camera Camera;

    // Start is called before the first frame update
    //
        public CharacterController controller;

        public float speed = 2f;
        public float walkspeed = 2f;
        public float sprintspeed = 8f;
      //  public float speed;
      //  public float jumpSpeed;
        public float gravity;
        private Vector3 movingDirection=Vector3.zero;

        public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    private float sensitivityX = 2F;
    private float sensitivityY = 2F;
    private float minimumX = -360F;
    private float maximumX = 120F;
    private float minimumY = -255F;
    private float maximumY = 120F;
    private float rotationX = 0F;
    private float rotationY = 0F;
    private Quaternion originalRotation;


        void Start()
        {
        Camera.GetComponent<Camera>().enabled = true;
        originalRotation = transform.localRotation;
        }
        void Update() {
            UpdateMouseLook();
        UpdateMovement();

        }

         private void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
                speed=sprintspeed;
            }
        else {
                speed=walkspeed;
            }
        if (controller.isGrounded) {
                movingDirection.y=2.0f;
            }

            movingDirection.y -=gravity * Time.deltaTime;
            controller.Move(movingDirection * Time.deltaTime);

            float z=Input.GetAxis("Vertical");
            Vector3 move=transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.2f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.2f, 0.0f, 0.0f);
        }

    }

    private void UpdateMouseLook()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }

        return Mathf.Clamp(angle, min, max);
    }
}