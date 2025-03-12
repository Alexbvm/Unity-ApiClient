using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Applicatie : MonoBehaviour
{

    public GegevensInput gegevensInput;
    public GameObject screens;
    private GameObject LoginScreen;
    private GameObject WereldSelect;
    private GameObject SpelWereld;
    public GameObject FouteInlogGegevens;

    [SerializeField] TextMeshProUGUI wereld1;
    [SerializeField] TextMeshProUGUI wereld2;
    [SerializeField] TextMeshProUGUI wereld3;
    [SerializeField] TextMeshProUGUI wereld4;
    [SerializeField] TextMeshProUGUI wereld5;

    [SerializeField] public string wereld1Id;
    [SerializeField] public string wereld2Id;
    [SerializeField] public string wereld3Id;
    [SerializeField] public string wereld4Id;
    [SerializeField] public string wereld5Id;

    public List<string> worldNames;
    public List<string> worldIds;
    public int currentEnvironment;
    public WorldButtonHandler worldButtonHandler;

    public List<Environment2D> environmentList; 

    [Header("Test data")]
    public User user;
    public Environment2D environment2D;
    public Object2D object2D;

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public Environment2DApiClient enviroment2DApiClient;
    public Object2DApiClient object2DApiClient;

    #region Login

    [ContextMenu("User/Register")]
    public async void Register()
    {
        gegevensInput.SetRegisterCredentials();
        user.email = gegevensInput.ReturnUsername();
        user.password = gegevensInput.ReturnPassword();     
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes!");  
                // TODO: Handle succes scenario;
                    break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Register error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }
    void Start()
    {
        LoginScreen = screens.transform.Find("LoginScreen").gameObject;
        WereldSelect = screens.transform.Find("WereldSelect").gameObject;
        SpelWereld = screens.transform.Find("SpelWereld").gameObject;
        //FouteInlogGegevens = screens.transform.Find("FouteInlogGegevens").gameObject;
    }
    [ContextMenu("User/Login")]
    public async void Login()
    {
        gegevensInput.SetLoginCredentials();
        user.email = gegevensInput.ReturninlogUsername();
        user.password = gegevensInput.ReturninlogPassword();
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Login succes!");
                // TODO: Todo handle succes scenario.
                LoginScreen.SetActive(false);
                WereldSelect.SetActive(true);
                ReadEnvironment2Ds();
                break;
            case WebRequestError errorResponse:
                FouteInlogGegevens.SetActive(true);
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Login error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

    #region Environment

    [ContextMenu("Environment2D/Read all")]
    public async void ReadEnvironment2Ds()
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.ReadEnvironment2Ds();

        //clean reset text velden
        wereld1.text = "";
        wereld2.text = "";
        wereld3.text = "";
        wereld4.text = "";
        wereld5.text = "";

        environmentList = new List<Environment2D>();

        switch (webRequestResponse)
        {
            case WebRequestData<List<Environment2D>> dataResponse:
                List<Environment2D> environment2Ds = dataResponse.Data;
                Debug.Log("List of environment2Ds: ");
                environment2Ds.ForEach(environment2D => Debug.Log(environment2D.id));
                // TODO: Handle succes scenario.
                int i = 1;
                foreach(Environment2D environment2D in environment2Ds)
                {
                    environmentList.Add(environment2D);

                    switch (i)
                    {
                        case 1:
                            wereld1.text = environment2D.name;
                            wereld1Id = environment2D.id;
                            break;
                        case 2:
                            wereld2.text = environment2D.name;
                            wereld2Id = environment2D.id;
                            break;
                        case 3:
                            wereld3.text = environment2D.name;
                            wereld3Id = environment2D.id;
                            break;
                        case 4:
                            wereld4.text = environment2D.name;
                            wereld4Id = environment2D.id;
                            break;
                        case 5:
                            wereld5.text = environment2D.name;
                            wereld5Id = environment2D.id;
                            break;

                    }
                    i++;
                }
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read environment2Ds error: " + errorMessage);    
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Environment2D/Create")]
    public async void CreateEnvironment2D()
    {

        Environment2D environment2D = new Environment2D();
        environment2D.name = worldButtonHandler.wereldAanmaken();
        environment2D.maxLength = 1080;
        environment2D.maxHeight = 1080;
        bool isNameDifferent = true;
        foreach (Environment2D e in environmentList)
        {
            if (e.name == environment2D.name)
            {
                isNameDifferent = false;
            }
        }

        var normalizedName = environment2D.name.Trim();
        if(normalizedName.Length >= 2 && normalizedName.Length <= 25 && isNameDifferent)
        {
            IWebRequestReponse webRequestResponse = await enviroment2DApiClient.CreateEnvironment(environment2D);
            //Debug.Log(worldButtonHandler.wereldAanmaken());

            switch (webRequestResponse)
            {
                case WebRequestData<Environment2D> dataResponse:
                    //environment2D.id = dataResponse.Data.id;
                    // TODO: Handle succes scenario.
                    Debug.Log("wereld aanmaken succes!");
                    ReadEnvironment2Ds();
                    WereldSelect.SetActive(false);
                    SpelWereld.SetActive(true);
                    break;
                case WebRequestError errorResponse:
                    string errorMessage = errorResponse.ErrorMessage;
                    Debug.Log("Create environment2D error: " + errorMessage);
                    // TODO: Handle error scenario. Show the errormessage to the user.
                    break;
                default:
                    throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
            }
        }
    }

    [ContextMenu("Environment2D/Delete")]
    public async void DeleteEnvironment2D(string id)
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.DeleteEnvironment(id);
        
        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                // TODO: Handle succes scenario.
                ReadEnvironment2Ds();
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete environment error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion Environment

    #region Object2D

    [ContextMenu("Object2D/Read all")]
    public async void ReadObject2Ds()
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.ReadObject2Ds(object2D.environmentId);

        switch (webRequestResponse)
        {
            case WebRequestData<List<Object2D>> dataResponse:
                List<Object2D> object2Ds = dataResponse.Data;
                Debug.Log("List of object2Ds: " + object2Ds);
                object2Ds.ForEach(object2D => Debug.Log(object2D.id));
                // TODO: Succes scenario. Show the enviroments in the UI
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read object2Ds error: " + errorMessage);
                // TODO: Error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Create")]
    public async void CreateObject2D(Object2D giveObject2D)
    {
        Environment2D e = environmentList[worldButtonHandler.huidigeKnop];
        giveObject2D.environmentId = e.id;
        IWebRequestReponse webRequestResponse = await object2DApiClient.CreateObject2D(giveObject2D);

        switch (webRequestResponse)
        {
            case WebRequestData<Object2D> dataResponse:
                //giveObject2D.id = dataResponse.Data.id;
                // TODO: Handle succes scenario.
                Debug.Log("object aangemaakt");
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create Object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Update")]
    public async void UpdateObject2D()
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.UpdateObject2D(object2D);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Update object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

}
