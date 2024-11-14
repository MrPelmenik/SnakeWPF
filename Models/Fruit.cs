using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_SNAKE.Models
{
    public class Fruit
    {
        public int row { get; set; }
        public int column { get; set; }

        public Fruit(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
