using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class controller : MonoBehaviour
{

    public float timeout = 1;
    public float timeout_default = 1;
    public float timeout_speed = 0.1f;
    public float score_points = 100;
    public float timer;
    private float score;
    private int linesDestroyed = 0;
    private int archievmentScore = 0;

    public GameObject[] cubeGroups;
    public static GameObject[] cubes;

    public static GameObject[,] cubeMatrix;

    private GameObject spawner;
    private GameObject currentGroup;
    private cubeGroup currentScript;
    private Text score_text;

    public enum inputs { empty, left, right, down, up, click, pressed };
    private int input;

    private bool newG = false;
    public bool debugMatrix = false;

    private SwipeDetector swipe;

    public AudioClip clip;
    private GameObject musicManager;

    private bool isGameOver;
    private bool isPaused;

    private bool pullDown;

    // Use this for initialization
    void Start()
    {
        isGameOver = false;
        isPaused = false;
        timer = 0;
        input = (int)inputs.empty;
        spawner = GameObject.FindGameObjectWithTag("spawner");
        cubeMatrix = new GameObject[20, 20];

        setCubes();

        timeout = timeout_default;

        swipe = GameObject.FindGameObjectWithTag("SwipeDetector").GetComponent<SwipeDetector>();

        score_text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        score = 0;
        pullDown = false;

        musicManager = GameObject.FindGameObjectWithTag("MusicManager");
        if (clip != null)
        {
            musicManager.SendMessage("newClip", clip);
        }

        if (ToverPlayService.instance.usePlayServices)
        {
            ToverPlayService.instance.FirstBrickArchievment();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.instance.paused)
            Debug.Log("PauseManager.instance.paused: " + PauseManager.instance.paused);
        if (isGameOver)
            Debug.Log("isGameOver: " + isGameOver);
        if (pullDown)
            Debug.Log("pullDown: " + pullDown);


        if (PauseManager.instance.paused == true)
            return;

        if (isGameOver == false)
        {

            setScore();

            if (currentGroup == null)
            {
                newGroup();
            }

            if (pullDown)
            {
                if (!currentScript.isGrounded())
                {
                    callGroup();
                }
                else
                {
                    newGroup();
                    newG = true;
                    timer = 0;
                    pullDown = false;
                }
                return;
            }

            if (currentScript.isReady)
            {
                setCubes();

                if (newG)
                {
                    if (currentScript.isGrounded())
                    {
                        gameOver();
                    }
                }



                getInput();

                if (input != (int)inputs.empty)
                {
                    if (input == (int)inputs.pressed)
                        timeout = timeout_speed;

                    if (input == (int)inputs.down)
                    {

                        setCubes();

                        /*
                        while (!currentScript.isGrounded())
                        {
                            callGroup();
                        }
                        newGroup();
                        newG = true;
                        timer = 0;
                        return;
                        */
                        pullDown = true;

                    }

                    callGroup();
                    newG = false;
                }

                //call only when timeout is over
                if (timer > timeout)
                {
                    setCubes();
                    if (currentScript.isGrounded())
                    {
                        newGroup();
                        newG = true;
                    }
                    else
                    {

                        //setCubes();
                        //set timer back
                        timer = 0;
                        callGroup();
                        newG = false;
                    }
                    timeout = timeout_default;
                }
                timer = timer + Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// reads the input of the user
    /// </summary>
    void getInput()
    {
        input = swipe.input;

        if (input != 0)
        {
            Debug.Log("empty, left, right, down, up, click, pressed");
            Debug.Log(input);
        }

        swipe.input = (int)inputs.empty;

        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WebGLPlayer)
        {
            if (Input.GetKeyDown("up"))
            {
                input = (int)inputs.click;
            }
            if (Input.GetKeyDown("right"))
            {
                input = (int)inputs.right;
            }
            if (Input.GetKeyDown("down"))
            {
                input = (int)inputs.down;
            }
            if (Input.GetKeyDown("left"))
            {
                input = (int)inputs.left;
            }
            if (Input.GetKey("space"))
            {
                input = (int)inputs.pressed;
            }
        }

    }


    /// <summary>
    /// get all cubes in the Scene
    /// </summary>
    void setCubes()
    {
        cubes = GameObject.FindGameObjectsWithTag("cube");
        //Debug.Log(cubes.Length);
        setMatrix();
    }

    /// <summary>
    /// set the matrix
    /// </summary>
    void setMatrix()
    {
        cubeMatrix = new GameObject[20, 20];
        foreach (GameObject cube in cubes)
        {
            int y = (int)cube.transform.position.y;
            int x = Mathf.RoundToInt(cube.transform.eulerAngles.y / 18);
            if (x < 0)
            {
                x = 20 + x; //-1 = 19
            }
            cubeMatrix[x, y] = cube;
        }
    }

    /// <summary>
    /// check if a line is full
    /// </summary>
    bool controlLines(out int i)
    {
        for (i = 0; i < 20; i++)
        {
            setCubes();
            int row = 0;
            for (int ii = 0; ii < 20; ii++)
            {
                if (cubeMatrix[ii, i] != null)
                    row++;
            }
            if (row == 20)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// put all cubes above the given line down
    /// </summary>
    void putLinesDown(int line)
    {
        setCubes();
        Debug.Log("put lines down");
        for (int i = line; i < 20; i++)
        {
            for (int ii = 0; ii < 20; ii++)
            {
                if (cubeMatrix[ii, i] != null)
                    cubeMatrix[ii, i].transform.Translate(0, -1, 0);
            }
        }
        setCubes();
    }

    /// <summary>
    /// deletes a line
    /// </summary>
    void deleteLine(int line)
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject.DestroyImmediate(cubeMatrix[i, line]);
            //GameObject.Destroy(cubeMatrix[i, line]);
            //Destroy(cubeMatrix[i, line]);
            cubeMatrix[i, line] = null;
        }
        linesDestroyed++;
        setCubes();
        putLinesDown(line + 1);
    }

    /// <summary>
    /// call the current Group
    /// </summary>
    void callGroup()
    {
        currentGroup.SendMessage("callGroup", input);
        input = (int)inputs.empty;
    }

    /// <summary>
    /// create a new Group
    /// </summary>
    void newGroup()
    {
        currentGroup = (GameObject)Instantiate(cubeGroups[Random.Range(0, cubeGroups.Length)], spawner.transform.position, spawner.transform.rotation);
        currentScript = currentGroup.GetComponent<cubeGroup>();
        setCubes();

        float score_multiplier = 1f;

        for (int i = 0; i < 4; i++)
        {
            int row = 0;
            setCubes();
            if (controlLines(out row))
            {
                deleteLine(row);
                setCubes();

                addScore(score_points * score_multiplier);
                score_multiplier = score_multiplier + 0.1f;

                if (timeout_default > timeout_speed)
                {

                    timeout_default = timeout_default - 0.0015f;
                    timeout = timeout_default;
                }
            }
        }
    }


    /// <summary>
    /// check if one Cube is above the gameOver Line
    /// </summary>
    void gameOver()
    {
        if (isGameOver == false)
        {
            isGameOver = true;

            if (ToverPlayService.instance.usePlayServices)
            {
                ToverPlayService.instance.postScoreToLeaderboard(score);
            }
            endGame();
        }
    }

    void endGame()
    {
        Debug.Log("gameOver");

        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WebGLPlayer)
        {
            GameObject.Destroy(musicManager);
            LoadingScreenManager.LoadScene(0);
            //SceneManager.LoadScene("mainmenu");
        }
        else
        {
            MobileNativeMessage msg = new MobileNativeMessage(ToverLanguage.instance.languageTable["GameOverHead"],
                ToverLanguage.instance.languageTable["GameOverBody"]);
            msg.OnComplete += OnMessageClose;
        }
    }

    public void OnMessageClose()
    {
        GameObject.Destroy(musicManager);
        LoadingScreenManager.LoadScene(0);
        //SceneManager.LoadScene("mainmenu");
    }



    void addScore(float points)
    {
        score = score + points;

        ToverPlayService.instance.CheckAchievements(score, archievmentScore);
    }

    void setScore()
    {
        score_text.text = score.ToString();
    }


    void OnGUI()
    {

        if (debugMatrix)
        {
            for (int i = 0; i < cubeMatrix.GetLength(0); i++)
            {
                GUI.Box(new Rect(i * 20, 20 * 20, 20, 20), i.ToString());
                for (int ii = 0; ii < cubeMatrix.GetLength(1); ii++)
                {
                    if (cubeMatrix[i, ii] != null)
                        GUI.Box(new Rect(i * 20, ii * 20, 20, 20), "+");
                    else
                        GUI.Box(new Rect(i * 20, ii * 20, 20, 20), "");

                }
            }
        }
    }
}
