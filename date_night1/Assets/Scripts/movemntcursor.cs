using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemntcursor : MonoBehaviour
{
    public float speed  = 5f;
    public Vector3 deltaMove;
    public GameObject player;
    public Vector2 turn;
    public float sens  =20f;
    float xRotation;
    float yRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {

        turn.x +=  Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        turn.y += Input.GetAxis("Mouse Y") * Time.deltaTime * sens;

        yRotation += turn.x;
        xRotation -= turn.y;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y,0, 0);
        deltaMove = new Vector3(Input.GetAxis("Horizontal") * speed*Time.deltaTime,0,Input.GetAxis("Vertical")* speed* Time.deltaTime);
        
    }
}
