using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JokenPo.Enums;
using System.Windows.Input;
using JokenPo.Models;

namespace JokenPo.ViewModel
{
    public partial class GameViewModel : ObservableObject

    {

        [ObservableProperty]
        private String imagem_Player1;

        [ObservableProperty]
        private String imagem_Player2;

        [ObservableProperty]
        private String nome_Player1;

        [ObservableProperty]
        private int pontuacao_Player1;

        [ObservableProperty]
        private int pontuacao_Player2;

        [ObservableProperty]
        private Escolha escolha_Player1;

        [ObservableProperty]
        private String resultado;

        public ICommand JogarCommand { get; }

        Player player1 = new Player();

        public GameViewModel()
        {
            JogarCommand = new Command(Jogar);
        }

        public void Jogar()
        {

            Player player2 = new Player();

            player1.Nome = Nome_Player1;
            player2.Nome = "Inimigo";

            player1.Escolha = Escolha_Player1;
            player2.Jogar();

            atualizaImagens(player1, player2);

            if (player1.Escolha == player2.Escolha)
            {
                Resultado = "Empatou";
            }
            else if(player1.Escolha == Escolha.Pedra && player2.Escolha == Escolha.Tesoura 
                || player1.Escolha == Escolha.Papel && player2.Escolha == Escolha.Pedra
                || player1.Escolha == Escolha.Tesoura && player2.Escolha == Escolha.Papel)
            {
                Resultado = $"{player1.Nome} venceu!";
                atualizaPontos(player1);
            }
            else
            {
                Resultado = $"{player2.Nome} venceu!";
                atualizaPontos(player2);
            }
        }

        public void atualizaPontos(Player jogador)
        {
            jogador.Pontuacao += 1;
        }

        public void atualizaImagens(Player jogador1, Player jogador2)
        {
            Imagem_Player1 = $"escolha{jogador1.Escolha}";
            Imagem_Player2 = $"escolha{jogador2.Escolha}";
        }

        public void reseta()
        {
           
        }

    }
}
