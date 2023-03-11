int countAllPurchase = 0;
int countAllBuyers = 0;
Queue<int> buyers = CreatingQueue();
ServeAllQueue(buyers, ref countAllBuyers, ref countAllPurchase);

static int GetQueuePeopleNumber()
{
    bool isOpen = true;
    int resault = 0;

    while (isOpen)
    {
        Console.WriteLine("Сколько человек в очереди?");
        string userInput = Console.ReadLine();
        int.TryParse(userInput, out int resaultParse);

        if (resaultParse >= 0)
        {
            resault = resaultParse;
            isOpen = false;
        }
        else
        {
            Console.WriteLine("Ошибка ввода. Введите другое число:");
        }
    }

    return resault;
}

static Queue<int> CreatingQueue()
{
    Random randomPurchaseCost = new Random();
    int lowerRandomNumber = 50;
    int upperRandomNumber = 1000;

    Queue<int> buyers = new Queue<int>();
    int amountBuyers = GetQueuePeopleNumber();

    for (int i = 0; i < amountBuyers; i++)
    {
        buyers.Enqueue(randomPurchaseCost.Next(lowerRandomNumber, upperRandomNumber));
    }

    return buyers;
}

static void ServeAllQueue(Queue<int> buyers, ref int countBuyers, ref int countPurchase)
{
    Console.WriteLine("Для обслуживания следующего клиента нажмите любую клавишу");
    buyers = buyers;
    countBuyers = countBuyers;
    countPurchase = countPurchase;

    while (buyers.Count > 0)
    {
        ShowInfoShop(buyers, ref countBuyers, ref countPurchase);
        ShowInfo();
        countPurchase += buyers.Dequeue();
    }

    ShowInfoShop(buyers, ref countBuyers, ref countPurchase);
}

static void ShowInfoShop(Queue<int> buyers, ref int countBuyers, ref int countPurchase)
{
    Console.Clear();
    countBuyers = buyers.Count;
    Console.SetCursorPosition(0, 5);
    Console.WriteLine("Количество человек в очереди - " + countBuyers);
    Console.WriteLine("Доход магазина - " + countPurchase);
}

static void ShowInfo()
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Для обслуживания следующего клиента нажмите любую клавишу");
    Console.ReadKey();
}