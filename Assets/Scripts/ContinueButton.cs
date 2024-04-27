using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    // Variables
    private Button button;
    [SerializeField] private string scene;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    private void TaskOnClick()
    {
        if (scene != null)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);

        }
    }
}
