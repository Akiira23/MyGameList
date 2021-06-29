using System;
namespace MyGameList.Classes
{
    public class Games : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo { get; set; }
        private int Ano_lancamento { get; set; }
        private Plataforma Plataforma { get; set; }
        private int Nota { get; set; }
        private bool Finalizado {get; set;}
        private bool Excluido {get; set;}

        public Games(int id, Genero genero, string titulo, int ano_lancamento, Plataforma plataforma, int nota, bool finalizado)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Ano_lancamento = ano_lancamento;
            this.Plataforma = plataforma;
            this.Nota = nota;
            this.Finalizado = finalizado;
            this.Excluido = false;
        }
        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Ano de lancamento: " + this.Ano_lancamento + Environment.NewLine;
            retorno += "Plataforma: " + this.Plataforma + Environment.NewLine;
            retorno += "Nota: " + this.Nota + Environment.NewLine;
            retorno += "Finalizado: " + this.Finalizado + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public int retornaNota()
		{
			return this.Nota;
		}
        public bool retornaFinalizado()
		{
			return this.Finalizado;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}