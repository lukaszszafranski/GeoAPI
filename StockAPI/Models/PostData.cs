using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Models
{
    public class PostData
    {
        public string Types { get; set; }
        public string Range { get; set; }
        public string Symbols { get; set; }
    }
}
