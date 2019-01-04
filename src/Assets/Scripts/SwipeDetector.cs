using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour
{

    public int input;
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector2 firstPoint;
    Vector2 secondPoint;
    bool swipeMove;

    private bool wasPaused = false;

    private float timer;
    private float swipeTimer;

    void Update()
    {
        if (PauseManager.instance.paused == true)
        {
            wasPaused = true;
            timer = 0;
            return;
        }

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SwipeTouch();
        }
        else
        {
            SwipeMouse();
        }
    }

    public void SwipeTouch()
    {
        if (Input.touches.Length > 0)
        {

            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                swipeMove = false;
                timer = 0;
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Stationary)
            {
                timer = timer + Time.deltaTime;
                if (timer > 0.3)
                {
                    input = (int)controller.inputs.pressed;

                }
            }
            if (t.phase == TouchPhase.Moved)
            {
                if (swipeMove == false)
                    firstPoint = firstPressPos;

                secondPoint = new Vector2(t.position.x, t.position.y);

                float d = firstPoint.x - secondPoint.x;

                //moved along the x axe % of the screen width
                if (Mathf.Abs(d) > (Screen.width * 0.15))
                {
                    if (d < 0)
                    {
                        // distance is negative -> nach rechts
                        input = (int)controller.inputs.right;
                    }
                    if (d > 0)
                    {
                        // distance is positive -> nach links
                        input = (int)controller.inputs.left;
                    }

                    firstPoint = secondPoint;
                    swipeMove = true;
                }








            }
            if (t.phase == TouchPhase.Ended)
            {
                if (wasPaused)
                {
                    wasPaused = false;
                    return;
                }

                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                if (timer < 0.3)
                {
                    if (Vector2.Distance(firstPressPos, secondPressPos) < (Screen.width * 0.08))
                    {
                        if (firstPressPos.y < Screen.height * 0.88)
                            input = (int)controller.inputs.click;

                        firstPressPos = Vector2.zero;
                        secondPressPos = Vector2.zero;

                        return;
                    }

                    //create vector from the two points
                    currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                    firstPressPos = Vector2.zero;
                    secondPressPos = Vector2.zero;

                    //normalize the 2d vector
                    currentSwipe.Normalize();

                    //swipe upwards
                    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        Debug.Log("up swipe");
                        //input = (int)controller.inputs.up;
                    }
                    //swipe down
                    if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        Debug.Log("down swipe");
                        input = (int)controller.inputs.down;
                    }
                    //swipe left
                    if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    {
                        Debug.Log("left swipe");
                        if (swipeMove == false)
                            input = (int)controller.inputs.left;
                    }
                    //swipe right
                    if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    {
                        Debug.Log("right swipe");
                        if (swipeMove == false)
                            input = (int)controller.inputs.right;
                    }
                }

                swipeMove = false;
            }

        }
    }

    public void SwipeMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeMove = false;
            timer = 0;
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            /*
            timer = timer + Time.deltaTime;
            if (timer > 0.3 && Vector2.Distance(firstPoint, new Vector2(Input.mousePosition.x, Input.mousePosition.y)) < 5)
            {

                input = (int)controller.inputs.pressed;

            }
            */

            if (swipeMove == false)
                firstPoint = firstPressPos;

            secondPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            float d = firstPoint.x - secondPoint.x;

            //moved along the x axe 10% of the screen width
            if (Mathf.Abs(d) > (Screen.width * 0.15))
            {
                if (d < 0)
                {
                    // distance is negative -> nach rechts
                    input = (int)controller.inputs.right;
                }
                if (d > 0)
                {
                    // distance is positive -> nach links
                    input = (int)controller.inputs.left;
                }

                firstPoint = secondPoint;
                swipeMove = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (wasPaused)
            {
                wasPaused = false;
                return;
            }

            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (timer < 0.3)
            {

                if (Vector2.Distance(firstPressPos, secondPressPos) < (Screen.width * 0.08))
                {
                    if (firstPressPos.y < Screen.height * 0.88)
                        input = (int)controller.inputs.click;
                    return;
                }


                //create vector from the two points
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                    input = (int)controller.inputs.down;
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                    if (swipeMove == false)
                        input = (int)controller.inputs.left;
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                    if (swipeMove == false)
                        input = (int)controller.inputs.right;
                }
            }

            swipeMove = false;
        }
    }

    void OnGUI()
    {
        //GUI.Box(new Rect(5, Screen.height - 60, 100, 20),"1: " + firstPressPos.x + "/" + firstPressPos.y);
        //GUI.Box(new Rect(5, Screen.height - 80, 100, 20),"2: " + secondPressPos.x + "/" + secondPressPos.y);
    }
}
