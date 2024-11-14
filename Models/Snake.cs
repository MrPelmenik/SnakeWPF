using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_SNAKE.Models
{
    public class Snake
    {
        public int row { get; set; }
        public int column { get; set; }
        public int value { get; set; }

        public Snake(int row, int column, int value)
        {
            this.row = row;
            this.column = column;
            this.value = value;
        }
    }
}
