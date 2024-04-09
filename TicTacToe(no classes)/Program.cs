Console.WriteLine("Введите первый символ: ");
char firstPlayerSymbol = Convert.ToChar(Console.ReadLine());

if (firstPlayerSymbol != 'X' || firstPlayerSymbol != '0')
    return;

char currentPlayerSymbol = firstPlayerSymbol;

char[,] field =
{
    {'-','-','-', },
    {'-','-','-', },
    {'-','-','-', }
};

while (true)
{
    Console.Clear();

    Draw();

    var position = GetPosition();




}

void Draw()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.WriteLine(field[i, j]);
        }

        Console.WriteLine();
    }
}

(int, int) GetPosition()
{
    var position = Console.ReadLine();

    var positionOne = position[0];
    var positionTwo = ;

    return (positionOne, positionTwo);
}

