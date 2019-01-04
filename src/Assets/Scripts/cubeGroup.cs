using UnityEngine;
using System.Collections;

public class cubeGroup : MonoBehaviour
{

    public static GameObject[] cubes;
    public GameObject cube;

    // y1,x1,y2,x2,y3,x3,y4,x4
    public int[] cubeOne;
    public int[] cubeTwo;
    public int[] cubeThree;
    public int[] cubeFour;
    public int groupRot;

    public bool isReady = false;

    public Spawner c;

    // Use this for initialization
    void Start()
    {
        c = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();

        cubes = new GameObject[4];
        groupRot = Random.Range(1, 4);

        cubes[0] = (GameObject)Instantiate(cube, this.transform.position, this.transform.rotation);
        cubes[1] = (GameObject)Instantiate(cube, this.transform.position, this.transform.rotation);
        cubes[2] = (GameObject)Instantiate(cube, this.transform.position, this.transform.rotation);
        cubes[3] = (GameObject)Instantiate(cube, this.transform.position, this.transform.rotation);

        //set parent
        cubes[0].transform.SetParent(this.transform);
        cubes[1].transform.SetParent(this.transform);
        cubes[2].transform.SetParent(this.transform);
        cubes[3].transform.SetParent(this.transform);

        if (groupRot == 1)
        {
            cubes[0].transform.Rotate(0, cubeOne[1] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[1] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[1] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[1] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[0], 0);
            cubes[1].transform.Translate(0, cubeTwo[0], 0);
            cubes[2].transform.Translate(0, cubeThree[0], 0);
            cubes[3].transform.Translate(0, cubeFour[0], 0);
        }
        if (groupRot == 2)
        {
            cubes[0].transform.Rotate(0, cubeOne[3] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[3] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[3] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[3] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[2], 0);
            cubes[1].transform.Translate(0, cubeTwo[2], 0);
            cubes[2].transform.Translate(0, cubeThree[2], 0);
            cubes[3].transform.Translate(0, cubeFour[2], 0);
        }
        if (groupRot == 3)
        {
            cubes[0].transform.Rotate(0, cubeOne[5] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[5] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[5] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[5] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[4], 0);
            cubes[1].transform.Translate(0, cubeTwo[4], 0);
            cubes[2].transform.Translate(0, cubeThree[4], 0);
            cubes[3].transform.Translate(0, cubeFour[4], 0);
        }
        if (groupRot == 4)
        {
            cubes[0].transform.Rotate(0, cubeOne[7] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[7] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[7] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[7] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[6], 0);
            cubes[1].transform.Translate(0, cubeTwo[6], 0);
            cubes[2].transform.Translate(0, cubeThree[6], 0);
            cubes[3].transform.Translate(0, cubeFour[6], 0);
        }
        isReady = true;
    }

    void Update()
    {
        if (this.gameObject.transform.childCount == 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void callGroup(int input)
    {
        switch (input)
        {
            case (int)controller.inputs.left:
                left();
                break;
            case (int)controller.inputs.right:
                right();
                break;
            case (int)controller.inputs.down:
                //putDown();
                break;
            case (int)controller.inputs.pressed:

                break;
            case (int)controller.inputs.click:
                turn();
                break;
            default:
                putDown();
                break;
        }

    }

    /// <summary>
    /// checks if the given position is already taken
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    bool isValide(int x, int y)
    {
        if (x >= 20)
            x = 20 - x;
        if (x < 0)
            x = 20 + x;

        if (controller.cubeMatrix[x, y] == null)
            return true;
        else if (controller.cubeMatrix[x, y].transform.gameObject.Equals(cubes[0]) || controller.cubeMatrix[x, y].transform.gameObject.Equals(cubes[1]) || controller.cubeMatrix[x, y].transform.gameObject.Equals(cubes[2]) || controller.cubeMatrix[x, y].transform.gameObject.Equals(cubes[3]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void right()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!isValide(Mathf.RoundToInt(cubes[i].transform.eulerAngles.y / 18 + 1), (int)cubes[i].transform.position.y))
            {
                return;
            }
        }
        c.right();
        this.transform.rotation = c.transform.rotation;
    }

    void left()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!isValide(Mathf.RoundToInt(cubes[i].transform.eulerAngles.y / 18 - 1), (int)cubes[i].transform.position.y))
            {
                return;
            }
        }
        c.left();
        this.transform.rotation = c.transform.rotation;

    }


    /// <summary>
    /// puts the cubeGroup down
    /// </summary>
    void putDown()
    {
        this.transform.Translate(0, -1, 0);
    }

    /// <summary>
    /// turns the cubeGroup
    /// </summary>
    void turn()
    {
        //turn clockwise
        if (groupRot == 1)
        {
            groupRot = 4;
        }
        else
        {
            groupRot--;
        }

        setCubes();
        if (isTurnCorrect() == false)
        {
            Debug.Log("turnIsNotCorrect");
            if (groupRot == 4)
            {
                groupRot = 1;
            }
            else
            {
                groupRot++;
            }
            setCubes();
        }

        //check if okay
        //if not, turn reverse clockwise
    }

    bool isTurnCorrect()
    {
        GameObject[] allCubes = GameObject.FindGameObjectsWithTag("cube");
        foreach (GameObject cube in allCubes)
        {
            int control = 0;
            foreach (GameObject cubeControll in allCubes)
            {
                if (Mathf.RoundToInt(cube.transform.eulerAngles.y / 18) == Mathf.RoundToInt(cubeControll.transform.eulerAngles.y / 18) &&
                   cube.transform.position.y == cubeControll.transform.position.y)
                {
                    control++;
                }
            }
            if (control > 1)
                return false;
            if (cube.transform.position.y < 0)
                return false;
        }
        return true;
    }

    /// <summary>
    /// set the cubes to a new position
    /// </summary>
    void setCubes()
    {
        cubes[0].transform.rotation = this.transform.rotation;
        cubes[1].transform.rotation = this.transform.rotation;
        cubes[2].transform.rotation = this.transform.rotation;
        cubes[3].transform.rotation = this.transform.rotation;

        cubes[0].transform.position = this.transform.position;
        cubes[1].transform.position = this.transform.position;
        cubes[2].transform.position = this.transform.position;
        cubes[3].transform.position = this.transform.position;

        if (groupRot == 1)
        {
            cubes[0].transform.Rotate(0, cubeOne[1] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[1] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[1] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[1] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[0], 0);
            cubes[1].transform.Translate(0, cubeTwo[0], 0);
            cubes[2].transform.Translate(0, cubeThree[0], 0);
            cubes[3].transform.Translate(0, cubeFour[0], 0);
        }
        if (groupRot == 2)
        {
            cubes[0].transform.Rotate(0, cubeOne[3] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[3] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[3] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[3] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[2], 0);
            cubes[1].transform.Translate(0, cubeTwo[2], 0);
            cubes[2].transform.Translate(0, cubeThree[2], 0);
            cubes[3].transform.Translate(0, cubeFour[2], 0);
        }
        if (groupRot == 3)
        {
            cubes[0].transform.Rotate(0, cubeOne[5] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[5] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[5] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[5] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[4], 0);
            cubes[1].transform.Translate(0, cubeTwo[4], 0);
            cubes[2].transform.Translate(0, cubeThree[4], 0);
            cubes[3].transform.Translate(0, cubeFour[4], 0);
        }
        if (groupRot == 4)
        {
            cubes[0].transform.Rotate(0, cubeOne[7] * 18, 0);
            cubes[1].transform.Rotate(0, cubeTwo[7] * 18, 0);
            cubes[2].transform.Rotate(0, cubeThree[7] * 18, 0);
            cubes[3].transform.Rotate(0, cubeFour[7] * 18, 0);

            cubes[0].transform.Translate(0, cubeOne[6], 0);
            cubes[1].transform.Translate(0, cubeTwo[6], 0);
            cubes[2].transform.Translate(0, cubeThree[6], 0);
            cubes[3].transform.Translate(0, cubeFour[6], 0);
        }
    }


    /// <summary>
    /// sets the grounded var to true if a cube cant go down
    /// </summary>
    public bool isGrounded()
    {
        setCubes();
        for (int i = 0; i < 4; i++)
        {
            //is on the ground?
            if (cubes[i].transform.position.y <= 0)
            {
                return true;
            }

            GameObject b = controller.cubeMatrix[Mathf.RoundToInt(cubes[i].transform.eulerAngles.y / 18), (int)(cubes[i].transform.position.y - 1)];



            if (b != null)
            {
                if (b.transform.parent.GetInstanceID() == cubes[i].transform.parent.GetInstanceID())
                {
                    //Debug.Log("cube is from group");
                }
                else
                {
                    return true;
                }
            }
            /*
            RaycastHit hit;
            Ray ray = new Ray(cubes[i].transform.position, Vector3.down);

            if (Physics.Raycast(ray, out hit,1))
            {
                if(hit.transform.gameObject.Equals(cubes[0]) || hit.transform.gameObject.Equals(cubes[1]) || hit.transform.gameObject.Equals(cubes[2]) || hit.transform.gameObject.Equals(cubes[3]))
                {
                    //cube from group
                    return false;
                }
                else
                {
                    //the cube isn't in this group, you are grounded
                    return true;
                }
            }
            */
        }
        return false;
    }

}
