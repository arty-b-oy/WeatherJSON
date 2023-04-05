using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetWeather : MonoBehaviour
{
    private const string URLWeather = "https://api.openweathermap.org/data/2.5/weather?q=Moscow&APPID=3c2fd3f39510ba8cb38e4715c6f17f67";

    [SerializeField] private WeatherView weatherView;
    [SerializeField] private GameObject errorPanel;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGet_Weather);
    }

    public void StartGet_Weather()
    {
        StartCoroutine(Get_Weather());
    }

    private IEnumerator Get_Weather()
    {
        errorPanel.SetActive(false);
        UnityWebRequest webRequest = UnityWebRequest.Get(URLWeather);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError)
        {
            Debug.LogError(webRequest.error);
            errorPanel.SetActive(true);
        }
        else
        {
            var myDeserializedClass = JsonUtility.FromJson<Root>(webRequest.downloadHandler.text);
            weatherView.WeatherPresent(myDeserializedClass);
        }
        
    }

}
