using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VSPlayerButton : MonoBehaviour
{
    // Variables
    private Button button;

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
        SceneManager.LoadSceneAsync("VSPlayer Stage 1");
    }
}
