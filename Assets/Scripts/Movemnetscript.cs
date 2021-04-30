using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemnetscript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float _yVelocity;
    private Vector3 directions;
    private Vector3 velocity;
    private CharacterController characterController;
    private bool _candoubleJump=false;
    private int _coins;
    private Uimanager _uimanager;
    // Start is called before the first frame update
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<Uimanager>();
        if (_uimanager == null)
        {
            Debug.LogError("Uimanager is null");
        }
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        directions = new Vector3(h,0,0);
        velocity = directions * speed;
        
        if(characterController.isGrounded == true)
        {
            
           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                _candoubleJump = true;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_candoubleJump == true)
                {
                    _yVelocity += jumpHeight*2;
                    _candoubleJump = false;
                }
               

            }
            
            _yVelocity -= gravity;
        }
        velocity.y = _yVelocity;
        characterController.Move(velocity*Time.deltaTime);
        
    }
    public void addCoins()
    {
        _coins++;
        _uimanager.updateScore(_coins);
       
    }
}
