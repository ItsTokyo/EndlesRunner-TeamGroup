using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 collidePush;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        collidePush = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z - 25f);
        if (other.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(collidePush * 10);
        }
    }
}
