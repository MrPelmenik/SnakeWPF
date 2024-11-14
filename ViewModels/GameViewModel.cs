using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

using WPF_MVVM.Commands;
using WPF_MVVM.Data;
using WPF_MVVM.Models;
using WPF_MVVM.ViewModels.Base;
using WPF_MVVM_SNAKE.Models;

namespace WPF_MVVM.ViewModels
{
    public enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }

    public enum Cell
    {
        Empty,
        SnakeHead, 
        SnakeTail,
        Fruit
    }

    public class GameViewModel : ViewModel
    {
        private readonly GameBoard gameBoard;
        private readonly Random random;
        private readonly int startSnakeSize = 3;
        private List<Snake> snakeBody;
        private List<Fruit> fruits;
        private Direction _direction;   
        private const int _delay = 500;
        private CancellationTokenSource _cts = null;
        public bool isPaused = true;
        public int[,] Board { get => gameBoard.board; private set => Set(ref gameBoard.board, value); }
        public int Score { get => gameBoard.score; private set => Set(ref gameBoard.score, value); }

        public bool IsPaused
        {
            get => isPaused;
            set => Set(ref isPaused, value);
        }

        public Direction Direction
        {
            get => _direction;
            set => _direction = value;
        }


        public GameViewModel()
        {
            gameBoard = new GameBoard();
            random = new Random();
            snakeBody = new List<Snake>();
            fruits = new List<Fruit>();

            ShiftLeftCommand = new RelayCommand(ShiftLeft);
            ShiftRightCommand = new RelayCommand(ShiftRight);
            ShiftDownCommand = new RelayCommand(ShiftDown);
            ShiftUpCommand = new RelayCommand(ShiftUp);
            ResetCommand = new RelayCommand(Reset);

            Reset();
            Direction = Direction.Up;

            Run();
        }

        #region Commands


    public  NavigationCommand NavigateToMenuPage { get => new(OnNavigate, NavigateToPage, new Uri("Views/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute)); }

        public RelayCommand MenuReturnCommand { get; init; }
        public RelayCommand ShiftLeftCommand { get; init; }
        public RelayCommand ShiftRightCommand { get; init; }
        public RelayCommand ShiftDownCommand { get; init; }
        public RelayCommand ShiftUpCommand { get; init; }
        public RelayCommand ResetCommand { get; init; }

        private void OnNavigate()
        {
            IsPaused = false;
        }
        #endregion

        #region Operations
        private void Reset()
        {
            Board = new int[gameBoard.boardSize, gameBoard.boardSize];
            snakeBody.Clear();
            fruits.Clear();
            IsPaused = true; // for start
            Score = 0;
            _direction = Direction.Up;
            SnakeToStartPosition();
            GenerateRandomFruit();
            Update();
        }

        private async void Run()
        {
            using (_cts = new CancellationTokenSource())
            {
                while (isPaused) // повторять, пока не надоест
                {
                    CheckGameState();
                    //GenerateRandomFruit();
                    SnakeMove(Direction);
                    CheckForFruit();
                    Update();

                    await Task.Delay(_delay, _cts.Token); 
                }
            }
        }


        private void SnakeToStartPosition ()
        {
            snakeBody.Add(new Snake(gameBoard.boardSize / 2, gameBoard.boardSize / 2, (int)Cell.SnakeHead));
            for (int i = 1; i != startSnakeSize; i++)
            {
                snakeBody.Add(new Snake(i+gameBoard.boardSize / 2, gameBoard.boardSize / 2, (int)Cell.SnakeTail));
            }
        }

        private void GenerateRandomFruit()
        {
            int row, col;

            do
            {
                row = random.Next(gameBoard.boardSize);
                col = random.Next(gameBoard.boardSize);
            } while (gameBoard.board[row, col] != (int)Cell.Empty);

            fruits.Add(new Fruit(row, col));
            gameBoard.board[row, col] = (int)Cell.Fruit;
        }

        public void CheckForFruit()
        {
            int headRow = snakeBody[0].row;
            int headColum = snakeBody[0].column;

            foreach (var fruit in fruits)
            {
                if (fruit.row == headRow && fruit.column == headColum)
                {
                    Score += 10;
                    fruits.Remove(fruit);
                    GenerateRandomFruit();
                    SnakeIncrease();
                    break;
                }
            }
        }

        private void SnakeIncrease ()
        {
            int lastRow = snakeBody[snakeBody.Count-1].row;
            int lastColum = snakeBody[snakeBody.Count-1].column;

            snakeBody.Add(new Snake(lastRow, lastColum, (int)Cell.SnakeTail));
        }

        private void Update()
        {
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int column = 0; column < gameBoard.boardSize; column++)
                {
                    if (gameBoard.board[row, column] == (int)Cell.SnakeHead || 
                        gameBoard.board[row, column] == (int)Cell.SnakeTail)
                    {
                        gameBoard.board[row, column] = (int)Cell.Empty;
                    }
                }
            }
            foreach (var snake in snakeBody)
            {
                gameBoard.board[snake.row, snake.column] = snake.value;
            }
            Board = gameBoard.Board;
            Score = gameBoard.Score;
        }
        #endregion

        #region GameState
        private void CheckGameState()
        {
            Update();
            if (IsGameOverCanibal() || IsGameOverOutOfRange(_direction))
            {
                isPaused = false;
                MessageBoxResult result = MessageBox.Show("Вы проиграли! Желаете занести себя в список?", "Конец", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    AddToStatistics();
                }

                Reset();
            }
            else if (IsGameWin())
            {
                isPaused = false;
                MessageBoxResult result = MessageBox.Show("Вы выиграли! Желаете занести себя в список?", "Конец", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    AddToStatistics();
                }

                Reset();
            }
        }

        public bool IsGameWin()
        {
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int column = 0; column < gameBoard.boardSize; column++)
                {
                    if (gameBoard.board[row, column] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsGameOverCanibal()
        {
            int headRow = snakeBody[0].row;
            int headColum = snakeBody[0].column;
            if (snakeBody.Skip(1).Any(x=> x.row == headRow && x.column == headColum))
            {
                return true;
            }
            return false;
        }
        private bool IsGameOverOutOfRange (Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    if (snakeBody[0].column + 1 == 12)
                        return true;
                    break;
                case Direction.Down:
                    if (snakeBody[0].row + 1 == 12)
                        return true;
                    break;
                case Direction.Left:
                    if (snakeBody[0].column - 1 == -1)
                        return true;
                    break;
                case Direction.Up:
                    if (snakeBody[0].row - 1 == -1)
                        return true;
                    break;
            }
            return false; 
        }




        #endregion

        #region Statistics
        private void AddToStatistics()
        {
            string name;

            do
            {
                name = Microsoft.VisualBasic.Interaction.InputBox("Введите ваше имя: ", "Ввод имени", "");
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Имя не может быть пустым. Пожалуйста, введите ваше имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } while (string.IsNullOrEmpty(name));

            Statistics.Add(name, Score.ToString());
        }
        #endregion

        #region Shifts
        public void SnakeMove (Direction direction)
        {

            for (int i = snakeBody.Count-1; i > 0; i--) // Прохождение хвоста
            {
                snakeBody[i].row = snakeBody[i - 1].row;
                snakeBody[i].column = snakeBody[i - 1].column;
            }

            switch (direction)
            {
                case Direction.Right:
                    snakeBody[0].column += 1;
                    break;
                case Direction.Down:
                    snakeBody[0].row += 1;
                    break;
                case Direction.Left:
                    snakeBody[0].column -= 1;
                    break;
                case Direction.Up:
                    snakeBody[0].row -= 1;
                    break;
            }
        }

        public void ShiftLeft()
        {
            if (_direction != Direction.Right)
                _direction = Direction.Left;
            CheckGameState();
        }

        public void ShiftRight()
        {
            if (_direction != Direction.Left)
                _direction = Direction.Right;
            CheckGameState();
        }

        public void ShiftDown()
        {
            if (_direction != Direction.Up)
                _direction = Direction.Down;
            CheckGameState();
        }

        public void ShiftUp()
        {
            if (_direction != Direction.Down)
                _direction = Direction.Up;
            CheckGameState();
        }
        #endregion
    }
}
