using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listCamera;

    private int _indexActualCamera = 0;

    public int indexActualCamera { 
        get { return _indexActualCamera; } 
        set {
            if (value < 0)
            {
                _indexActualCamera = 0;
            }
            else if (value > _listCamera.Count)
            {
                _indexActualCamera = _listCamera.Count;
            }
            else
            {
                _indexActualCamera = value;
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            indexActualCamera -= 1;
            SwitchCamera();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            indexActualCamera += 1;
            SwitchCamera();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SwitchCamera()
    {
        for (int i = 0; i < _listCamera.Count; i++)
        {
            if (indexActualCamera == i)
            {
                _listCamera[i].SetActive(true);
            }
            else
            {
                _listCamera[i].SetActive(false);
            }
        }
    }
}
