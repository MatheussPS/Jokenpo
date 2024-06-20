using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JokenPo.Enums;

namespace JokenPo.Models
{
    public class Player
    {

        public String Nome { get; set; }
        public int Pontuacao { get; set; }
        public Escolha Escolha { get; set; }

        public void Jogar()
        {
            Escolha = (Escolha)new Random().Next(3);
        }
    }
}
