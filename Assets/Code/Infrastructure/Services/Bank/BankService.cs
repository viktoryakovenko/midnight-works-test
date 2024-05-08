using Services.PersistentProgress;
using System;

namespace Services.Bank
{
    public class BankService : IBankService
    {
        public event Action<int> OnCoinsChanged;
        public event Action<int> OnDiamondsChanged;

        public int Coins => _coins;
        public int Diamonds => _diamonds;

        private int _coins;
        private int _diamonds;

        public BankService(IPersistentProgressService progressService) 
        {
            _coins = progressService.Progress.CurrenciesData.Coins;
            _diamonds = progressService.Progress.CurrenciesData.Diamonds;
        }

        public void AddCoins(int amount)
        {
            TryChange(amount);

            _coins += amount;
            OnCoinsChanged?.Invoke(_coins);
        }

        public void WithdrawCoins(int amount)
        {
            TryChange(amount);

            _coins -= amount;
            OnCoinsChanged?.Invoke(_coins);
        }

        public void AddDiamonds(int amount)
        {
            TryChange(amount);

            _diamonds += amount;
            OnDiamondsChanged?.Invoke(_diamonds);
        }

        public void WithdrawDiamonds(int amount)
        {
            TryChange(amount);

            _diamonds -= amount;
            OnDiamondsChanged?.Invoke(_diamonds);
        }

        private void TryChange(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
        }
    }

}