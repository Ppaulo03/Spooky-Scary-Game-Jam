using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Signal pressButton = null, pickObject = null;

    [SerializeField] private GameObject item = null;

    [SerializeField] private GlobalBool hasItem = null;
    
    [SerializeField] private CharacterController controller = null;

    [SerializeField] private Transform groundCheck = null;

    [SerializeField] private LayerMask groundMask = ~0;

    [SerializeField] private float speed = 12f, gravity = -9.81f, groundDistance = 0.4f;

    private Vector3 velocity;

    public bool haveItem = false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) pressButton.Raise();
        if(Input.GetKeyDown(KeyCode.F)){
            if(hasItem.Value){
                item.transform.GetChild (0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.GetChild (0).gameObject.transform.SetParent(null);
                hasItem.Value = false;
            }
            else pickObject.Raise();
        }
        if(Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) velocity.y = -2f;
        else velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        Vector3 move = transform.right*Input.GetAxis("Horizontal") + transform.forward*Input.GetAxis("Vertical");
        controller.Move(move*speed*Time.deltaTime);
    }

}
