const char PlayerCross = 'X';
const char PlayerCircle = '0';
const string ExitCommand = "exit";
const char EmptyPosition = '-';
const int fieldSize = 3;

bool isIdentification = true;
bool isGaming = true;

char[,] field =
{
    {EmptyPosition,EmptyPosition,EmptyPosition, },
    {EmptyPosition,EmptyPosition,EmptyPosition, },
    {EmptyPosition,EmptyPosition,EmptyPosition, }
};

Console.WriteLine($"Введите Х, 0 или {ExitCommand} для выхода: ");
string firstPlayerSymbol = Console.ReadLine();

while (isIdentification)
{
    if (firstPlayerSymbol.ToUpper() != Convert.ToString(PlayerCross) && firstPlayerSymbol.ToUpper() != Convert.ToString(PlayerCircle))
    {
        ErrorInputMessage();

        firstPlayerSymbol = Console.ReadLine();

        Console.Clear();
    }

    else if(firstPlayerSymbol.ToLower() == ExitCommand)
    {
        Console.WriteLine("Выход из программы.");
        break;
    }
    else
    {
        break;
    }
}

char currentPlayerSymbol = Convert.ToChar(firstPlayerSymbol);

while (isGaming)
{
    Console.Clear();

    Draw();

    var position = GetPosition();

    bool occupityPosition = CheckOccupityPosition(position);

    if (occupityPosition == true)
    {
        ErrorMessage();
        continue;
    }

    field[position.Item1, position.Item2] = currentPlayerSymbol;

    bool isWin = CheckWin(currentPlayerSymbol);
    if (isWin == true)
        return;

    bool isDraw = CheckDraw();
    if (isDraw == true)
        return;

    currentPlayerSymbol = currentPlayerSymbol == PlayerCross ? PlayerCircle : PlayerCross;
}

void Draw()
{
    for (int i = 0; i < fieldSize; i++)
    {
        for (int j = 0; j < fieldSize; j++)
        {
            Console.Write(field[i, j]);
        }

        Console.WriteLine();
    }
}

(int, int) GetPosition()
{
    while (true)
    {
        var position = Console.ReadLine();

        if(CheckValidityEnteredPosition(position))
        {
            var positionOne = int.Parse(position[0].ToString());
            var positionTwo = int.Parse(position[1].ToString());

            return (positionOne, positionTwo);
        }
        else
        {
            Console.Clear();

            ErrorInputMessage();

            Draw();
        }
    }
}

bool CheckValidityEnteredPosition(string position)
{
    int positionY, positionX;

    if (position.Length != 2)
        return false;

    if (!int.TryParse(position[0].ToString(), out positionY) || !int.TryParse(position[1].ToString(), out positionX))
        return false;

    if (positionY is not >= 0 and <= 2 || positionX is not >= 0 and <= 2)
        return false;

    return true;
}

bool CheckOccupityPosition((int y, int x) position)
{
    if(field[position.Item1, position.Item2] != EmptyPosition)
        return true;

    return false;
}

void ErrorMessage()
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine("Эта клетка занята. Попробуй другую.");

    Console.ForegroundColor = ConsoleColor.Gray;

    Thread.Sleep(1500);
}

bool CheckWin(char symbol)
{
    if (field[0, 0] == symbol && field[0, 1] == symbol && field[0, 2] == symbol
    ||  field[1, 0] == symbol && field[1, 1] == symbol && field[1, 2] == symbol
    ||  field[2, 0] == symbol && field[2, 1] == symbol && field[2, 2] == symbol
    ||  field[0, 0] == symbol && field[1, 1] == symbol && field[2, 2] == symbol
    ||  field[0, 2] == symbol && field[1, 1] == symbol && field[2, 0] == symbol
    ||  field[0, 0] == symbol && field[1, 0] == symbol && field[2, 0] == symbol
    ||  field[0, 1] == symbol && field[1, 1] == symbol && field[2, 1] == symbol
    ||  field[0, 2] == symbol && field[1, 2] == symbol && field[2, 2] == symbol)
    {
        Console.WriteLine($"{symbol} победил.");

        return true; 
    }

    return false;
}

bool CheckDraw()
{
    for(int i = 0; i < fieldSize; i++)
    {
        for(int j = 0; j < fieldSize; j++)
        {
            if (field[i, j] == EmptyPosition)
                return false;
        }
    }

    Console.WriteLine("Ничья");

    return true;
}

void ErrorInputMessage()
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine("Введите корректный запрос.");

    Console.ForegroundColor= ConsoleColor.Gray;
}