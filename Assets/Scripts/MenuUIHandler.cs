using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField NameTexto;
    public Text TextScore;
    // Start is called before the first frame update
    void Start()
    {
        ManagerData.Instance.LoadPoints();
        NameTexto.text = ManagerData.Instance.NombreGamer;
        ManagerData.Instance.NameInput = NameTexto;

        TextScore.text = $"Best Score : {ManagerData.Instance.NombreGamer} : {ManagerData.Instance.Points}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        ManagerData.Instance.NameInput = NameTexto;
        //ManagerData.Instance.SavePoints();
        SceneManager.LoadScene(1);
    }
}
