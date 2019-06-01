using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public string Mensage { get; set; }
        public object Data { get; set; }
    }
}
