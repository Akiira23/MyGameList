using System;
using System.Collections.Generic;
using MyGameList.Interfaces;

namespace MyGameList
{
    public class GameRepositorio : IRepositorio<Games>
    {
        private List<Games> listaGames = new List<Games>();
        public void Atualiza(int id, Games entidade)
        {
            listaGames[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaGames[id].Excluir();
        }

        public void Insere(Games entidade)
        {
            listaGames.Add(entidade);
        }

        public List<Games> Lista()
        {
            return listaGames;
        }

        public int ProximoId()
        {
            return listaGames.Count;
        }

        public Games RetornaPorId(int id)
        {
            return listaGames[id];
        }
    }
}