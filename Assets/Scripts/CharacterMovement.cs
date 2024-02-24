using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Tilemap map;
    [SerializeField] float movementSpeed;
    MouseInput mouseinput;
    private Vector3 destination;
    private void Awake()
    {
        mouseinput = new MouseInput();
    }
    private void OnEnable()
    {
        //Enables the input action when script is enabled
        mouseinput.Enable();
    }
    private void OnDisable()
    {
        //Enables the input action when script is disabled
        mouseinput.Disable();
    }
    void Start()
    {
        //Subscribe to the click event
        //call MouseClick function
        mouseinput.Mouse.MouseClick.performed += _ => MouseClick();
        destination = transform.position;
    }
    private void MouseClick()
    {
        //Camera reference
        var maincam = Camera.main;
        //Return mouse position in pixel coordinates
        //Based off screen size from (0,0) to the (screen width, screen height)
        Vector2 mousepos = mouseinput.Mouse.MousePosition.ReadValue<Vector2>();

        //transverts pixels to a WorldPoint. pass in mouse position
        mousepos = maincam.ScreenToWorldPoint(mousepos);

        //Keeps character movement locked to inside the grid
        Vector3Int gridPosition = map.WorldToCell(mousepos);
        if (map.HasTile(gridPosition))
        {
            destination = mousepos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the character move to the destination based on their movement speed
        if (Vector3.Distance(transform.position, destination) > 0.1f)
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
    }
}
