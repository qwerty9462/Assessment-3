using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene : MonoBehaviour
{
    public void JumpTo(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
