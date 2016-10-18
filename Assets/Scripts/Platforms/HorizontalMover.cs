using UnityEngine;
using System.Collections;

public class HorizontalMover : MonoBehaviour
{

    public Transform placeholders;

    [Range(0.0f, 10.0f)]
    public float velocity;

    #region READONLY

    private readonly int LEFT_PLACEHOLDER = 0;
    private readonly int RIGHT_PLACEHOLDER = 1;
    private readonly Vector2 RIGHT = Vector2.right;
    private readonly Vector2 LEFT = Vector2.left;

    #endregion

    void Start()
    {
        velocity = 0.2f;
    }

    void FixedUpdate()
    {
        PlatformReturn();
    }


    void PlatformReturn()
    {
        if (this.transform.position.x >= placeholders.GetChild(0).transform.position.x)
        {
            this.transform.Translate(LEFT * velocity);
        }
        else
        {
            this.transform.Translate(RIGHT * velocity);
        }
    }
}
