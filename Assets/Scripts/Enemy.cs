using UnityEngine;

public class Enemy : IEnemy
{
    private string _name;
    private int _maxCrimeLevel = 5;

    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;
    private int _crimePlayer;

    public Enemy(string name, int maxCrimeLevel)
    {
        _name = name;
        _maxCrimeLevel = maxCrimeLevel;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                var dataHealth = (Health)dataPlayer;
                _healthPlayer = dataHealth.CountHealth;
                break;

            case DataType.Power:
                var dataPower = (Power)dataPlayer;
                _powerPlayer = dataPower.CountPower;
                break;

            case DataType.Money:
                var dataMoney = (Money)dataPlayer;
                _moneyPlayer = dataMoney.CountMoney;
                break;

            case DataType.Crime:
                var dataCrime = (Crime)dataPlayer;
                _crimePlayer = dataCrime.CountCrime;
                break;
        }
        Debug.Log($"Enemy {_name}, change {dataType}");
    }

    public int Power
    {
        get
        {
            if(_healthPlayer < 3)
            {
                var power = _healthPlayer + _moneyPlayer - 3;
                return power;
            }
            else
            {
                var power = _healthPlayer + _moneyPlayer;
                return power;
            }

        }
    }
    public int MaxCrimeLevel
    {
        get 
        { 
            return _maxCrimeLevel; 
        }
    }

}
