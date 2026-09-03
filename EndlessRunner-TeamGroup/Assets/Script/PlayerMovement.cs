using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour

{
    public Vector3 playerPos;
    private PlayerInputs input;
    private Rigidbody rb;
    private Vector3 moveUp;
    private Vector3 moveDown;
    public float speed;

    [SerializeField] private TimerScaler scaler;
    void Awake()
    {
        input = new PlayerInputs();
        input.Movement.Up.performed += ctx => MoveUp();
        input.Movement.Down.performed += ctx => MoveDown();
        input.Movement.Interact.performed += ctx => Interact();

        
        speed = 7;
        Debug.Log(speed);

        rb = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        StartCoroutine(SpeedIncrease());
    }
    private void Interact()
    {
        Debug.Log("Interact");
    }


    void FixedUpdate()
    {
        //Gets players pos every frame
        playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Moves player forward
        MoveForward();
    }

    void Update()
    {

    }

    private IEnumerator SpeedIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);

            speed += 1 * scaler.timeScale;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void MoveUp()
    {
        if (playerPos.y < 13f)
        {
            
           
            moveUp += new Vector3(playerPos.x, playerPos.y += 7, playerPos.z);
            transform.position = playerPos;
            Debug.Log("Up");
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void MoveDown()
    {
        if (playerPos.y > 0)
        {
            
            moveDown += new Vector3(playerPos.x, playerPos.y -= 7, playerPos.z);
            transform.position = playerPos;
            Debug.Log("Down");
        }
    }

    private void MoveForward()
    {
        playerPos.x += Time.deltaTime * speed;
        transform.position = playerPos;
    }
    void OnEnable()
    {
        input.Movement.Enable();
    }

    void OnDisable()
    {
        input.Movement.Disable();
    }

    public void IsAlive()
    {
        
    }
    
}