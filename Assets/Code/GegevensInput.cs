using TMPro;
using UnityEngine;

public class GegevensInput : MonoBehaviour
{
    [SerializeField] TMP_InputField emailRegisterField;
    [SerializeField] TMP_InputField passwordRegisterField;
    [SerializeField] TMP_InputField emailLoginField;
    [SerializeField] TMP_InputField passwordLoginField;

    private string registerUsername;
    private string registerPassword;
    private string inlogUsername;
    private string inlogPassword;
    public void SetRegisterCredentials()
    {
        Debug.Log(registerPassword);
        Debug.Log(registerUsername);
        registerUsername = emailRegisterField.text;
        registerPassword = passwordRegisterField.text;
    }
    public void SetLoginCredentials()
    {
        inlogUsername = emailLoginField.text;
        inlogPassword = passwordLoginField.text;
    }

    public void SetWereldGegevens()
    {

    }

    public string ReturnUsername()
    {
        return registerUsername;
    }

    public string ReturnPassword()
    {
        return registerPassword;
    }

    public string ReturninlogUsername()
    {
        return inlogUsername;
    }

    public string ReturninlogPassword()
    {
        return inlogPassword;
    }
}
