namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
        public int Id { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }


        public static List<Suite> suitesDisponiveis()
        {

            List<Suite>listSuites =new List<Suite> 
            {
                new Suite {Id=1,TipoSuite="Basica", Capacidade=2, ValorDiaria=25.00M},
                new Suite {Id=2,TipoSuite="Media", Capacidade=3, ValorDiaria=35.00m},
                new Suite {Id=3,TipoSuite="Premium", Capacidade=4, ValorDiaria=50.00m},
                new Suite {Id=4,TipoSuite="Master", Capacidade=6, ValorDiaria=75.99M},
            };
            return listSuites;
        }


    }
}