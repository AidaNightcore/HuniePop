using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TokenBehaviour : MonoBehaviour
{
    private Vector2 initialPosition;
    private Vector2 finalPosition;
    private Vector2 tempPosition;
    
    private float swipeAngle = 0;

    public int column; 
    public int row; 
    private GameObject swappableToken;
    private Board board;

    public int targetX; 
    public int targetY;
    private bool isPressed  = false;
    
    void Start()
    {
        board = FindFirstObjectByType<Board>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
    }

    void Update()
    {
        targetX = column;
        targetY = row;

        if (Mathf.Abs(targetX - transform.position.x) > .1f)
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
        }
        else
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
            board.allTokens[column,row] = this.gameObject;
        }
        
        if (Mathf.Abs(targetY - transform.position.y) > .1f)
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
        }
        else
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
            board.allTokens[column,row] = this.gameObject;
        }
        
    }


    private void OnMouseDown()
    {
        initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalPosition.y - initialPosition.y, finalPosition.x - initialPosition.x)*180/Mathf.PI;
        Debug.Log("swipeAngle: " + swipeAngle);
        MovePieces();
    }

    void MovePieces()
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && column<board.width - 1)
        {
            swappableToken = board.allTokens[column+1, row];
            swappableToken.GetComponent<TokenBehaviour>().column -= 1;
            column += 1; 
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row < board.height - 1)
        {
            swappableToken = board.allTokens[column, row+1];
            swappableToken.GetComponent<TokenBehaviour>().row -=1;
            row += 1; 
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && column > 0)
        {
            swappableToken = board.allTokens[column-1, row];
            swappableToken.GetComponent<TokenBehaviour>().column += 1;
            column -= 1; 
        }
        else if ((swipeAngle < -45 && swipeAngle >= -135) && row > 0)
        {
            swappableToken = board.allTokens[column, row-1];
            swappableToken.GetComponent<TokenBehaviour>().row += 1;
            row -= 1; 
        }
    }
}
