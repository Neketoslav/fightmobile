using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class FightWindowView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countMoneyText;
    [SerializeField] private TMP_Text _countPowerText;
    [SerializeField] private TMP_Text _countHealthText;
    [SerializeField] private TMP_Text _countCrimeText;
    [SerializeField] private TMP_Text _countPowerEnemyText;

    [SerializeField] private Button _plusMoneyButton;
    [SerializeField] private Button _minusMoneyButton;

    [SerializeField] private Button _plusPowerButton;
    [SerializeField] private Button _minusPowerButton;

    [SerializeField] private Button _plusHealthButton;
    [SerializeField] private Button _minusHealthButton;

    [SerializeField] private Button _plusCrimeButton;
    [SerializeField] private Button _minusCrimeButton;

    [SerializeField] private Button _fightButton;

    private int _allCountMoneyPlayer;
    private int _allCountPowerPlayer;
    private int _allCountHealthPlayer;
    private int _allCountCrimePlayer;

    private Money _money;
    private Power _power;
    private Health _health;
    private Crime _crime;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = new Enemy("Enemy Car", 2);

        _money = new Money();
        _money.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        _health = new Health();
        _health.Attach(_enemy);

        _crime = new Crime();
        _crime.Attach(_enemy);

        _plusMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _plusPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _plusHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _plusCrimeButton.onClick.AddListener(() => ChangeCrime(true));
        _minusCrimeButton.onClick.AddListener(() => ChangeCrime(false));

        _fightButton.onClick.AddListener(Fight);
    }

    private void ChangeCrime(bool isAddCount)
    {
        if (isAddCount)
            _allCountCrimePlayer++;
        else
            _allCountCrimePlayer--;

        ChangeDataWindow(_allCountCrimePlayer, DataType.Crime);

    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);

    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void Fight()
    {
        if(_allCountCrimePlayer >= _enemy.MaxCrimeLevel)
        {
            Debug.Log(_allCountPowerPlayer >= _enemy.Power ? "Win" : "Lose");
        }
        else
        {
            Debug.Log("you escaped");
        }
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money: {countChangeData}";
                _money.CountMoney = countChangeData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player Power: {countChangeData}";
                _power.CountPower = countChangeData;
                break;

            case DataType.Health:
                _countHealthText.text = $"Player Health: {countChangeData}";
                _health.CountHealth= countChangeData;
                break;

            case DataType.Crime:
                _countCrimeText.text = $"Player Crime: {countChangeData}";
                _crime.CountCrime = countChangeData;
                break;
        }

        _countPowerEnemyText.text = $"Enemy Power: {_enemy.Power}";
    }

    private void OnDestroy()
    {
        _plusMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _plusPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _plusHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _plusCrimeButton.onClick.RemoveAllListeners();
        _minusCrimeButton.onClick.RemoveAllListeners();

        _fightButton.onClick.AddListener(Fight);

        _money.Detach(_enemy);

        _power.Detach(_enemy);

        _health.Detach(_enemy);

        _crime.Detach(_enemy);
    }

}
