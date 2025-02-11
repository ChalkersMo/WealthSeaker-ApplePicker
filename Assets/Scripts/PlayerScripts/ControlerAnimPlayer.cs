using UnityEngine;

public class ControlerAnimPlayer : MonoBehaviour
{
    public bool IsAxe;
    public bool IsUniqueAxe;
    public bool IsGoldenAxe;

    public int playerStrength;
    public int LogsBoost; 
    public float speed = 5f;
    private Animator animator;

    public GameObject ItteractionSign;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;
    CharacterController controller;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 1f;

    public bool Gathering;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();  
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!Gathering)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

            if (Input.GetKey(KeyCode.W)) animator.SetInteger("State", 0);
            else if (Input.GetKey(KeyCode.S)) animator.SetInteger("State", 0);
            else if (Input.GetKey(KeyCode.A)) animator.SetInteger("State", 0);
            else if (Input.GetKey(KeyCode.D)) animator.SetInteger("State", 0);
            else animator.SetInteger("State", 1);

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                animator.SetInteger("State", 2);
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            Vector3 moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * direction;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
