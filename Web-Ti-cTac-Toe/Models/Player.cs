using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Tic_Tac_Toe.Models
{
    public class Player
    {
        public int[,] Field { get; set; } = new int[,] { { 0, 0, 0 }, { 0, 0, 0 } };
        public byte[] Score { get; set; } = new byte[] { 0, 0 };
    }
}