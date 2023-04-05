using System;
using TMPro;
using UnityEngine;

public class WeatherView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dataTemp;
    [SerializeField] private TextMeshProUGUI _dataFeelsLike;
    [SerializeField] private TextMeshProUGUI _dataTempMin;
    [SerializeField] private TextMeshProUGUI _dataTempMax;
    [SerializeField] private TextMeshProUGUI _dataPressure;
    [SerializeField] private TextMeshProUGUI _dataHumidity;
    [SerializeField] private TextMeshProUGUI _dataSpeed;
    [SerializeField] private GameObject _body;
    private const double kelvinAndCelsiusDifference = 273.15;

    public void WeatherPresent(Root root)
    {
        _dataTemp.text = KelvinToCelsiusInString(root.main.temp); 
        _dataFeelsLike.text = KelvinToCelsiusInString(root.main.feels_like);
        _dataTempMin.text = KelvinToCelsiusInString(root.main.temp_min);
        _dataTempMax.text = KelvinToCelsiusInString(root.main.temp_max);
        _dataPressure.text = root.main.pressure.ToString();
        _dataHumidity.text = root.main.humidity.ToString();
        _dataSpeed.text = root.wind.speed.ToString();
        _body.SetActive(true);

    }

    private string KelvinToCelsiusInString(double temp) 
    {
        return Math.Round(temp - kelvinAndCelsiusDifference, 2).ToString();
    }
}
