using System;

namespace Console_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2차원 배열을 생성 (10 x 10)
            char[,] map =
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', 'S', '#', ' ', ' ', ' ', ' ', ' ', '#', '#'},
                {'#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#'},
                {'#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', ' ', '#', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', '#', ' ', '#', '#', ' ', '#'},
                {'#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
                {'#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', '#'},
                {'#', 'G', '#', '#', ' ', '#', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            // 캐릭터 시작 지점 XY 좌표
            int playerX = 1;
            int playerY = 1;

            // 도착 지점 XY 좌표
            int goalX = 1;
            int goalY = 8;

            // 반복문
            while (true)
            {
                Console.Clear(); // 콘솔 화면 비우기
                DrawMap(playerX, playerY, goalX, goalY, map); // 맵과 캐릭터 표시

                ConsoleKey keyInput = Console.ReadKey().Key; // 콘솔 키 입력
                int newX = playerX; // 플레이어가 이동할 새로운 X좌표
                int newY = playerY; // 플레이어가 이동할 새로운 Y좌표

                switch (keyInput)
            {
                case ConsoleKey.UpArrow: // 윗 방향키 위로 이동
                    newY--;
                    break;

                case ConsoleKey.DownArrow: // 아랫 방향키 아래 이동
                    newY++;
                    break;

                case ConsoleKey.LeftArrow: // 왼쪽 방향키 왼쪽 이동
                    newX--;
                    break;

                case ConsoleKey.RightArrow: // 오른쪽 방향키 오른쪽 이동
                    newX++;
                    break;
            }

            // 이동 가능한 지역인지 확인
            if (IsPossibleMove(newX, newY, map))
            {
                playerX = newX; // 이동이 가능하다면 새로운 플레이어의 X좌표
                playerY = newY; // 이동이 가능하다면 새로운 플레이어의 Y좌표
            }
            // 플레이어가 도착 지점에 도달 하엿는지 확인
            if (playerX == goalX && playerY == goalY)
            {
                DrawMap(playerX, playerY, goalX, goalY, map); // 맵 그리기
                Console.WriteLine("미로를 풀었습니다!"); // 게임 종료 출력 문구
            }
        }
    }

    // 맵 드로우 메서드
    static void DrawMap(int playerX, int playerY, int goalX, int goalY, char[,] map)
    {
        int height = map.GetLength(0); // 높이
        int width = map.GetLength(1); // 넓이
        for (int y = 0; y < height; y++) // 10 x 10 높이 반복
        {
            for (int x = 0; x < width; x++) // 10 x 10 넓이 반복
            {
                // 플레이어 위치 변경 지점
                if (x == playerX && y == playerY)
                    Console.Write('U'); // 플레이어 유저
                else if (x == goalX && y == goalY)
                    Console.Write('G'); // 도착 지점
                else
                    Console.Write(map[y, x]); // 벽, 시작지점, 목표지점 등
            }
            Console.WriteLine(); // 줄 바꿈
        }
    }

    // 플레이어가 이동가능한지 확인 여부
    static bool IsPossibleMove(int x, int y, char[,] map)
    {
        return map[y, x] == ' ' || map[y, x] == 'G'; // 공백인 경우에만 이동 가능, 또는 도착지점에 이동 가능에 대한 반환값

        // 도착 지점에 도달하여도  "미로를 풀었습니다" 문구가 뜨지 않습니다.... 어떻게 수정 해야할까요.........
    }
}
}