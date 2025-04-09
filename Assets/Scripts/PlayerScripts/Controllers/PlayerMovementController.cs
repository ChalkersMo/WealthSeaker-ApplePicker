using System.Collections;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public int playerStrength;
    public float speed = 5f;
    public float jumpHeight = 1f;

    public Vector2 Axis;
    public bool isGroundedAfterJump = false;


    [SerializeField] private Transform cam;
    [SerializeField] private Collider AppeGatheringCollider;
    [SerializeField] private Collider PunchCollider;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private float gravity = -9.81f * 7;

    private CharacterController controller;
    private Vector3 velocity;

    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CheckInputs()
    {
        Axis.x = Input.GetAxisRaw("Horizontal");
        Axis.y = Input.GetAxisRaw("Vertical");
    }

    public void Run()
    {
        CheckInputs();

        Vector3 direction = new Vector3(Axis.x, 0f, Axis.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
       

        Vector3 moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * direction;
        controller.Move(speed * Time.deltaTime * moveDir.normalized);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        StartCoroutine(jump());
        IEnumerator jump()
        {
            while (true)
            {
                isGrounded = Physics.CheckBox(groundCheck.position, new Vector3(0.5f, groundDistance, 0.5f), Quaternion.identity, groundMask);

                if (isGrounded && isGroundedAfterJump)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    isGroundedAfterJump = false;
                }

                if (isGrounded && velocity.y < 0)
                    break;

                yield return new WaitForSeconds(0.2f);
            }
            isGroundedAfterJump = true;
        }   
    }

    public void PickUpItem()
    {
        AppeGatheringCollider.enabled = false;
    }
    public void OnAppleGatheringCollider()
    {
        AppeGatheringCollider.enabled = true;
    }

    public void Punch()
    {
        PunchCollider.enabled = true;
    }
}
