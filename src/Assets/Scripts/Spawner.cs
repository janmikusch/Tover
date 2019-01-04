using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    int rotationPos = 0;

    public void right()
    {
        rotationPos++;
        if (rotationPos == 20)
            rotationPos = 0;

        setRotation();
    }

    public void left()
    {
        rotationPos--;
        if (rotationPos == -1)
            rotationPos = 19;

        setRotation();
    }

    private void setRotation()
    {
        this.transform.rotation = Quaternion.Euler(0, Mathf.Round(rotationPos * 18), 0);
    }
}
