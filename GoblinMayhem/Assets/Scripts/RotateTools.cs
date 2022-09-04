using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTools : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeedFloat;

    Vector2 direction;

    private GameObject currentTool;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    // Start is called before the first frame update
    void Start()
    {
        currentTool = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // use this line for instant-rotation
        transform.rotation = targetRotation;

        // use this line for rotation over time
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeedFloat);

    }

    public void RotateTool()
    {
        Vector2 toolPosition = currentTool.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - toolPosition;
        currentTool.transform.right = direction;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
