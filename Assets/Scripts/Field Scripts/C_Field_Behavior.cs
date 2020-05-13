using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Field_Behavior : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 MinCameraPos;
    public Vector3 MaxCameraPos;
    public bool Bounds;
    public float SmoothTimeY;
    public float SmoothTimeX;

    private GameObject player;
    private Vector2 velocity;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, SmoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, SmoothTimeY);

        transform.position = new Vector3(posX, posY, offset.z);

        if (Bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x),
                                             Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y),
                                             Mathf.Clamp(transform.position.z, MinCameraPos.z, MaxCameraPos.z));
        }
    }
}
