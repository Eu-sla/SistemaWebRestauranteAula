namespace SistemaWebRestaurante.Models
{
    public class Produto
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string? nome;

		public string? Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		private int quantidade;

		public int Quantidade
		{
			get { return quantidade; }
			set { quantidade = value; }
		}

		private string? descricao;

		public string? Descricao
		{
            get { return descricao; }
			set { descricao = value; }
		}

		private decimal? valor;

		public decimal? Valor
		{
			get { return valor; }
			set { valor = value; }
		}




	}
}
