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
        private String nome_Player2;

        [ObservableProperty]
        private int pontuacao_Player1;

        [ObservableProperty]
        private int pontuacao_Player2;

        [ObservableProperty]
        private String escolha_Player1;

        [ObservableProperty]
        private String resultado;

        public ICommand JogarCommand { get; }
        public ICommand ResetarCommand { get; }

        Player player1 = new Player();
        Player player2 = new Player();


        public GameViewModel()
        {
            JogarCommand = new Command(Jogar);
            ResetarCommand = new Command(Reseta);
            resultado = "Joguem!";
            Nome_Player1 = "Você";
            Nome_Player2 = "Oponente";
            Imagem_Player1 = "game.png";
            Imagem_Player2 = "game.png";
            Escolha_Player1 = "Pedra";
        }

        public void Jogar()
        {

            player1.Nome = Nome_Player1;
            player2.Nome = "Inimigo";

            Escolha Escolha_Player = ConvertToEscolha(Escolha_Player1);
            player1.Escolha = Escolha_Player;
            player2.Jogar();

            AtualizaImagens();
            AtualizaJogo();
            AtualizaPontos();
            VerificaPontos();
        }

        public void AtualizaPontos()
        {
            Pontuacao_Player1 = player1.Pontuacao;
            Pontuacao_Player2 = player2.Pontuacao;

        }

        public void AtualizaPontos(Player jogador)
        {
            jogador.Pontuacao += 1;

        }

        public void AtualizaImagens()
        {
            Imagem_Player1 = $"escolha{((int)player1.Escolha)}.png";
            Imagem_Player2 = $"escolha{((int)player2.Escolha)}.png";
        }

        public void Reseta()
        {

            player1.Nome = Nome_Player1;
            player2.Nome = "Inimigo";

            player1.Pontuacao = 0;
            player2.Pontuacao = 0;

            AtualizaPontos();

            Imagem_Player1 = "game.png";
            Imagem_Player2 = "game.png";
            Resultado = "Joguem!";
        }

        public void AtualizaJogo()
        {
            if (player1.Escolha == player2.Escolha)
            {
                Resultado = $"Empatou";
            }
            else if (player1.Escolha == Escolha.Pedra && player2.Escolha == Escolha.Tesoura
                || player1.Escolha == Escolha.Papel && player2.Escolha == Escolha.Pedra
                || player1.Escolha == Escolha.Tesoura && player2.Escolha == Escolha.Papel)
            {
                Resultado = $"{player1.Nome} venceu a partida!";
                AtualizaPontos(player1);
            }
            else
            {
                Resultado = $"{player2.Nome} venceu a partida!";
                AtualizaPontos(player2);
            }
        }

        public async void VerificaPontos()
        {

            if (player1.Pontuacao == 10)
            {
                Resultado = $"{player1.Nome} venceu a rodada! O jogo será reiniciado em 5s";
                await Task.Delay(5000);
                Reseta();
            }
            else if (player2.Pontuacao == 10)
            {
                Resultado = $"{player2.Nome} venceu a rodada! O jogo será reiniciado em 5s";
                await Task.Delay(5000);
                Reseta();

            }


        }

        public static Escolha ConvertToEscolha(String palavra)
        {
            switch (palavra)
            {
                case "Pedra":
                    return Escolha.Pedra;
                case "Papel":
                    return Escolha.Papel;
                case "Tesoura":
                    return Escolha.Tesoura;
                default:
                    throw new ArgumentException("Valor não reconhecido");
            }
        }

    }
}

