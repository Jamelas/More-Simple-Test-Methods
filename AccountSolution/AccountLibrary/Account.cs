using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary
{
    public class Account
    {
        private decimal _balance;
        private decimal _overdraftLimit;
        private AccountState _state;

        public Account(decimal balance, decimal overdraftLimit)
        {
            _balance = balance;
            _overdraftLimit = overdraftLimit;
        }

        public decimal Balance
        {
            get => _balance;
        }

        public decimal OverdraftLimit
        {
            get => _overdraftLimit;
        }

        public AccountState State
        {
            get => _state;
        }

        public void Deposit(decimal amount)
        {
            if (CheckGreaterThanNegative(amount)) _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (CheckGreaterThanNegative(amount))
            {
                decimal _availableBalance = _balance + _overdraftLimit;
                AccountState _newState = CheckODState(_availableBalance, amount);
                if (_newState != AccountState.NotAllowed)
                {
                    _balance -= amount;
                    _state = _newState;
                }
            }
        }

        private bool CheckGreaterThanNegative(decimal amount)
        {
            return amount > 0 ? true : false;
        }

        private AccountState CheckODState(decimal availableBalance, decimal amount)
        {
            if (amount > availableBalance) return AccountState.NotAllowed;
            if (amount == availableBalance) return AccountState.ODLimit;
            if (amount > _balance) return AccountState.InOD;
            if (amount < _balance) return AccountState.Safe;
            return AccountState.None;
        }
    }
}
