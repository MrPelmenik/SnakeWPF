using System;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.Models
{
    public class GameBoard : ViewModel
    {
        public readonly int boardSize = 12;

        public int[,] board;
        public int score;

        public int[,] Board { get => board; set => Set(ref board, value); }
        public int Score { get => score; set => Set(ref score, value); }
    }
}
