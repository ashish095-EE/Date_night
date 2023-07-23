
using UnityEngine;

public class movementplayer : MonoBehaviour
{

    public float speed  = 5f;
    public float Jumpforce  = 5f;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed*Time.deltaTime,0,Input.GetAxis("Vertical")* speed* Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true){


            playerRb.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            
            
        }
        
    }

    public void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "ground"){
            isOnGround = true;
        }
        
        
    }

    public void OnCollisionExit(Collision collision) {
        if(collision.gameObject.tag == "ground"){
            isOnGround = false;
        }
        
        
    }
}
