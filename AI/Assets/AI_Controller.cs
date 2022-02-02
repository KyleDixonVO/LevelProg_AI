using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour
{
    //static float speed = 10000.0f;
    public Vector3 defaultMoveH = new Vector3(1 * 1000, 0, 0);
    public Vector3 defaultMoveZ = new Vector3(0, 0, 1 * 1000);
    public bool flipMovement = false;
    public Vector3 movementBehaviour;
    public bool movesHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        if (movesHorizontal)
        {
            movementBehaviour = defaultMoveH;
        }
        else
        {
            movementBehaviour = defaultMoveZ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flipMovement == false)
        {
            this.GetComponent<Rigidbody>().velocity = movementBehaviour;
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = -movementBehaviour;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("Collided with object");
            if (flipMovement == true)
            {
                flipMovement = false;
            }
            else
            {
                flipMovement = true;
            }
        }
        
    }
}
