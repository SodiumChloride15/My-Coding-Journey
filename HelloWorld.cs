using System;
using System.Threading;

public class Program
{
    static Random random = new Random();
    static bool shouldExit = false;

    static int height;
    static int width;

    static int playerX = 0;
    static int playerY = 0;

    static int foodX = 0;
    static int foodY = 0;

    static string[] states = { "('-')", "(^-^)", "(X_X)" };
    static string[] foods = { "@@@@@", "$$$$$", "#####" };

    static string player = states[0];
    static int food = 0;

    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        height = Console.WindowHeight - 1;
        width = Console.WindowWidth - 1;

        InitializeGame();

        while (!shouldExit)
        {
            Move();
        }
    }

    static void ShowFood()
    {
        food = random.Next(0, foods.Length);

        int maxFoodX = Math.Max(0, width - foods[food].Length);
        int maxFoodY = Math.Max(0, height);

        foodX = random.Next(0, maxFoodX + 1);
        foodY = random.Next(1, maxFoodY + 1);

        Console.SetCursorPosition(foodX, foodY);
        Console.Write(foods[food]);
    }

    static void DrawPlayer()
    {
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }

    static void ErasePlayer(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(new string(' ', player.Length));
    }

    static void Move()
    {
        int lastX = playerX;
        int lastY = playerY;

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                playerY--;
                break;
            case ConsoleKey.DownArrow:
                playerY++;
                break;
            case ConsoleKey.LeftArrow:
                playerX--;
                break;
            case ConsoleKey.RightArrow:
                playerX++;
                break;
            case ConsoleKey.Escape:
                shouldExit = true;
                return;
        }

        playerX = Math.Max(0, Math.Min(playerX, width - player.Length));
        playerY = Math.Max(0, Math.Min(playerY, height));

        ErasePlayer(lastX, lastY);
        DrawPlayer();

        if (playerX == foodX && playerY == foodY)
        {
            player = states[1];
            DrawPlayer();
            Thread.Sleep(300);

            player = states[0];
            DrawPlayer();

            ShowFood();
        }
    }

    static void InitializeGame()
    {
        Console.Clear();
        ShowFood();
        DrawPlayer();
    }
}