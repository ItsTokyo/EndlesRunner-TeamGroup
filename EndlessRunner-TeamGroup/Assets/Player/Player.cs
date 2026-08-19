using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector3 movementDir;

    public Input movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        movement = new Input();
        movement.Player.Movement.performed += ctx => movementDir = ctx.ReadValue<Vector3>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        transform.Translate(movementDir * Time.deltaTime);
        
    }
}
