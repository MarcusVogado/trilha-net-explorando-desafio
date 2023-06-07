namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes,Suite suite)
        {

            var quantidadePessoas = hospedes.Count <= ObterCapacidadeSuite(suite)?true:false; ;
            if (quantidadePessoas)
            {   
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Erro Quantidade de Hospedes maior que a capacidade da suite selecionada");
               
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterCapacidadeSuite(Suite suite)
        {
			var disponivel = Suite.suitesDisponiveis().FirstOrDefault(s => s.Id == suite.Id);
			if (disponivel != null)
			{
				return disponivel.Capacidade;
			}
			return 0;
		}

        public int ObterQuantidadeHospedes()
        {
         return Hospedes.Count;
        }

        public decimal CalcularValorDiaria(Suite suite,int diasReservados)
        {            
            decimal valor = 0;
            var desconto= diasReservados >= 10 ? true : false;
            if (desconto)
            {
				valor = (suite.ValorDiaria * diasReservados)-(suite.ValorDiaria * diasReservados) *0.1M;
                return valor;
			}
			valor = suite.ValorDiaria * diasReservados;
			return valor;
        }
    }
}