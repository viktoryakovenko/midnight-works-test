using System;

namespace Services.Bank
{
    public interface IBankService
    {
        int Coins { get; }
        int Diamonds { get; }

        event Action<int> OnCoinsChanged;
        event Action<int> OnDiamondsChanged;

        void AddCoins(int amount);
        void AddDiamonds(int amount);
        void WithdrawCoins(int amount);
        void WithdrawDiamonds(int amount);
    }
}