using System.Collections.Generic;
using cadastro_series.Interfaces;

namespace cadastro_series
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>(); 
        public void Atualiza(int id, Filme entidade)
        {
            listaFilme[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filme entidade)
        {
            listaFilme.Add(entidade);
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornarPorId(int id)
        {
            return listaFilme[id];
        }
    }
}