using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int movementSpeed = 4; //this is intended to be in pixels, so it would take ~8 frames to move one tile
    int pastDirs = 1;

    //is there more clear documentation where I can find each of these datatypes functions?
    private Rigidbody2D character;

    private Vector2 pastMovementDirection, movementDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        character = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        pastMovementDirection = movementDirection;
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(pastMovementDirection == movementDirection){
            pastDirs++;
            if(pastDirs >= 10){
                pastDirs = 10;
            }
        }else{
            pastDirs = 1;
        }
    }

    void FixedUpdate(){
        character.linearVelocity = movementDirection * movementSpeed * (1 + pastDirs/10);
    }
}
