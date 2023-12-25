using System;

public class BankAccount
{
    private int accountNumber;
    private string accountOwner;
    private float balance;

    // Конструктор для создания счета
    public BankAccount(int accountNumber, string accountOwner, float balance)
    {
        this.accountNumber = accountNumber;
        this.accountOwner = accountOwner;
        this.balance = balance;
    }

    // Метод для внесения денег
    public void dob(float amount)
    {
        balance += amount;
    }

    // Метод для снятия денег
    public void umen(float amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счете");
        }
    }

    // Метод для перевода денег на другой счет
    public void Transfer(BankAccount targetAccount, float amount)
    {
        if (amount <= balance)
        {
            Console.WriteLine($"Перевод {amount} рублей со счета {accountNumber} на счет {targetAccount.GetAccountNumber()}");
            balance -= amount;
            targetAccount.dob(amount);
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счете");
        }
    }

    // Метод для снятия всей суммы
    public void obnul()
    {
        balance = 0;
        Console.WriteLine("Со счета снята вся сумма");
    }

    // Метод для вывода информации об аккаунте
    public void Out()
    {
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Владелец счета: {accountOwner}");
        Console.WriteLine($"Баланс: {balance} рублей");
    }

    // Метод для получения номера счета
    public int GetAccountNumber()
    {
        return accountNumber;
    }

    // Метод для получения баланса
    public float GetBalance()
    {
        return balance;
    }
}
