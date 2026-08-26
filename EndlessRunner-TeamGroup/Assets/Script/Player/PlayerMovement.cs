using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour

{
    public Vector3 playerPos;
    private PlayerInputs input;
    private Rigidbody rb;
    private Vector2 moveUp;
    private Vector2 moveDown;

    void Awake()
    {
        input = new PlayerInputs();
        input.Movement.Up.performed += ctx => MoveUp();
        input.Movement.Down.performed += ctx => MoveDown();
        input.Movement.Interact.performed += ctx => Interact();




        rb = GetComponent<Rigidbody>();

    }

    private void Interact()
    {
        Debug.Log("Interact");
    }


    void FixedUpdate()
    {
        playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    void Update()
    {

    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void MoveUp()
    {
        if (playerPos.y <= 15f)
        {
            
            moveUp += new Vector2(playerPos.x, playerPos.y += 7);
            transform.position = moveUp;
            Debug.Log("Up");
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void MoveDown()
    {
        if (playerPos.y <= 15)
        {
            moveDown += new Vector2(playerPos.x, playerPos.y -= 7);
            transform.position = moveDown;
            Debug.Log("Down");
        }
    }
        void OnEnable()
        {
            input.Movement.Enable();
        }

        void OnDisable()
        {
            input.Movement.Disable();
        }
}
