using UnityEngine;
using System.Collections;

public class HorizontalMover : MonoBehaviour
{

    public Transform horPlaceholders;
    public Transform verPlaceholders;

    public bool isVert;

    [Range(0.0f, 10.0f)]
    public float velocity;

    #region READONLY

    private readonly int LEFT_PLACEHOLDER = 0;
    private readonly int RIGHT_PLACEHOLDER = 1;
    private readonly int UP_PLACEHOLDER = 0;
    private readonly int DOWN_PLACEHOLDER = 1;

    #endregion

    private Vector2 directionHor = Vector2.left;
    private Vector2 directionVer = Vector2.down;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (!isVert)
        {
            MoveHor();
        }

        if (isVert)
        {
            MoveVert();
        }
    }

    void MoveHor()
    {
        this.transform.Translate(directionHor * velocity);
        if (directionHor.Equals(Vector2.left) && this.transform.position.x < horPlaceholders.GetChild(LEFT_PLACEHOLDER).transform.position.x)
        {
            this.directionHor = Vector2.right;
        }
        else if (directionHor.Equals(Vector2.right) && this.transform.position.x >= horPlaceholders.GetChild(RIGHT_PLACEHOLDER).transform.position.x)
        {
            this.directionHor = Vector2.left;
        }
    }


    void MoveVert()
    {
        this.transform.Translate(directionVer * velocity);
        if (directionVer.Equals(Vector2.down) &&
            this.transform.position.y < verPlaceholders.GetChild(DOWN_PLACEHOLDER).transform.position.y)
        {
            this.directionVer = Vector2.up;
        }
        else if (directionVer.Equals(Vector2.up) &&
                 this.transform.position.y >= verPlaceholders.GetChild(UP_PLACEHOLDER).transform.position.y)
        {
            this.directionVer = Vector2.down;
        }
    }
}