using System;

public class BankAccount
{
    private static List<BankAccount> accounts = new List<BankAccount>();
    private int accountNumber;
    private string accountOwner;
    private float balance;

    // Конструктор для создания счета
    private BankAccount(int accountNumber, string accountOwner, float balance)
    {
        this.accountNumber = accountNumber;
        this.accountOwner = accountOwner;
        this.balance = balance;
    }

    // Метод для внесения денег
    private void dob(float amount)
    {
        balance += amount;
    }
    private static void PerformAccountOperations(BankAccount account)
    {
        bool exitAccountMenu = false;

        while (!exitAccountMenu)
        {
            Console.WriteLine($"Выбран счет {account.GetAccountNumber()}");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Внести деньги");
            Console.WriteLine("2. Снять деньги");
            Console.WriteLine("3. Перевести деньги на другой счет");
            Console.WriteLine("4. Информация о счете");
            Console.WriteLine("5. Снять всю сумму");
            Console.WriteLine("6. Вернуться в главное меню");

            int accountChoice = int.Parse(Console.ReadLine());

            switch (accountChoice)
            {
                case 1:
                    Console.WriteLine("Введите сумму для внесения:");
                    float depositAmount = float.Parse(Console.ReadLine());
                    account.dob(depositAmount);
                    Console.WriteLine($"Внесено {depositAmount} рублей");
                    Console.WriteLine();
                    break;

                case 2:
                    //снятие налички
                    Console.WriteLine("Введите сумму для снятия:");
                    float withdrawAmount = float.Parse(Console.ReadLine());
                    account.umen(withdrawAmount);
                    Console.WriteLine($"Снято {withdrawAmount} рублей");
                    Console.WriteLine();
                    break;
                case 3:
                    //перевод
                    Console.WriteLine("Введите номер счета, на который хотите передать деньги:");
                    int targetAccountNumber = int.Parse(Console.ReadLine());

                    BankAccount targetAccount = accounts.Find(acc => acc.GetAccountNumber() == targetAccountNumber);

                    if (targetAccount != null)
                    {
                        Console.WriteLine("Введите сумму для перевода:");
                        float transferAmount = float.Parse(Console.ReadLine());
                        account.Transfer(targetAccount, transferAmount);
                        Console.WriteLine($"Переведено {transferAmount} рублей на счет {targetAccountNumber}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Целевой счет не найден.");
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    //показать информацию о счете
                    Console.WriteLine("Информация о счете:");
                    account.Out();
                    Console.WriteLine();
                    break;
                case 5:
                    account.obnul();
                    Console.WriteLine("Со счета снята вся сумма. Баланс: 0");
                    break;

                case 6:
                    exitAccountMenu = true;
                    break;

                default:
                    Console.WriteLine("Введено некорректное значение.");
                    Console.WriteLine();
                    break;
            }
        }
    }
    // Метод для снятия денег
    private void umen(float amount)
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
    private void Transfer(BankAccount targetAccount, float amount)
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
    private void obnul()
    {
        balance = 0;
        Console.WriteLine("Со счета снята вся сумма");
    }

    // Метод для вывода информации об аккаунте
    private void Out()
    {
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Владелец счета: {accountOwner}");
        Console.WriteLine($"Баланс: {balance} рублей");
    }

    // Метод для получения номера счета
    private int GetAccountNumber()
    {
        return accountNumber;
    }

    // Метод для получения баланса
    private float GetBalance()
    {
        return balance;
    }
    public static void ZapuskRaket()
    {
        Start();
    }
    private static void Start()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать новый счет");
            Console.WriteLine("2. Выбрать счет");
            Console.WriteLine("3. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите номер счета:");
                    int newAccountNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите имя владельца:");
                    string newAccountOwner = Console.ReadLine();
                    Console.WriteLine("Введите начальный баланс:");
                    float newInitialBalance = float.Parse(Console.ReadLine());

                    accounts.Add(new BankAccount(newAccountNumber, newAccountOwner, newInitialBalance));

                    Console.WriteLine($"Счет {newAccountNumber} создан.");
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Введите номер счета:");
                    int selectedAccountNumber = int.Parse(Console.ReadLine());

                    BankAccount selectedAccount = accounts.Find(acc => acc.GetAccountNumber() == selectedAccountNumber);

                    if (selectedAccount != null)
                    {
                        PerformAccountOperations(selectedAccount);
                    }
                    else
                    {
                        Console.WriteLine("Счет не найден.");
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Введено некорректное значение.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
