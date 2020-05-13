using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Field_Behavior : MonoBehaviour
{
    public float Speed;
    public float Distance;
    public Transform GroundDetection;
    public BoxCollider2D PatrolArea;

    private bool FacingLeft = true;

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, Distance);
        if(groundInfo.collider == false)
        {
            if(FacingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                FacingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                FacingLeft = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == PatrolArea)
        {
            if (FacingLeft)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                FacingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                FacingLeft = true;
            }
        }
    }
}
