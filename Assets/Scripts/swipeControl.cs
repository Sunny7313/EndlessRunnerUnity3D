using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeControl : MonoBehaviour
{
    public PlayerController player;  
    public float swipeThreshold = 50f;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwiping = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isSwiping = true;
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    touchEndPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        touchEndPos = touch.position;
                        DetectSwipe();
                        isSwiping = false;
                    }
                    break;
            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                touchStartPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                touchEndPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0) && isSwiping)
            {
                touchEndPos = Input.mousePosition;
                DetectSwipe();
                isSwiping = false;
            }
        }
    }

    void DetectSwipe()
    {
        Vector2 swipe = touchEndPos - touchStartPos;
        if (swipe.magnitude > swipeThreshold)
        {
            if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
            {
                if (swipe.x > 0)
                    player.MoveRight();
                else
                    player.MoveLeft();
            }
            else
            {
                if (swipe.y > 0)
                    player.Jump();
                else
                    player.Slide();
            }
        }
    }
}
