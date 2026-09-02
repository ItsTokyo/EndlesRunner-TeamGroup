using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject player;
    private PlayerInputs input;
    public Vector3 playerPos;
    private Vector3 moveUp;
    private Vector3 moveDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        input = new PlayerInputs();
        input.Movement.Up.performed += ctx => MoveUp();
        input.Movement.Down.performed += ctx => MoveDown();
        input.Movement.Interact.performed += ctx => Interact();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets players pos every frame
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        
    }

    //List of Button interactions
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    
    private void Interact()
    {
        Debug.Log("Interact");
    }
    
    public void MoveUp()
    {
        if (playerPos.y < 13f)
        {
            
           
            moveUp += new Vector3(playerPos.x, playerPos.y += 7, playerPos.z);
            player.transform.position = playerPos;
            Debug.Log("Up");
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void MoveDown()
    {
        if (playerPos.y > 0)
        {
            
            moveDown += new Vector3(playerPos.x, playerPos.y -= 7, playerPos.z);
            player.transform.position = playerPos;
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
