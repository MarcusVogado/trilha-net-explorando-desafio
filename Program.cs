using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");
Pessoa p3 = new Pessoa(nome: "Hóspede 3");
Pessoa p4 = new Pessoa(nome: "Hóspede 4");

hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);
hospedes.Add(p4);


var listSuitesDisponiveis = Suite.suitesDisponiveis();
SelecionarSuite:
Console.WriteLine("VEJA QUAL OPÇÃO IRÁ ATENDE-LO(A) MELHOR E ESCOLHA O CÓDIGO DA SUITE DESEJADA");
foreach (var suit in listSuitesDisponiveis)
{
	Console.WriteLine($" Código: {suit.Id}, Tipo: {suit.TipoSuite} ,Capacidade: {suit.Capacidade}, Valor da diária{suit.ValorDiaria.ToString("C2")} ");
}
Console.WriteLine("DIGITE O CÓDIGO DESEJADO: ");
var idSelecionado = Convert.ToInt32(Console.ReadLine());

// Cria a suíte
Suite suite = Suite.suitesDisponiveis().FirstOrDefault(s => s.Id == idSelecionado);

if (suite == null)
{
	Console.WriteLine("O CÓDIGO DA SUITE É INEXISTENTE SELECIONE UM CÓDIGO DISPONÍVEL NA LISTA");
	goto SelecionarSuite;
}

Console.WriteLine("INFORME A QUANTIDADE DE DIÁRIAS IRÁ PRECISAR: A PARTIR DE 10 DIAS  VOCÊ GANHA UM DESCONTO DE 10%");
var diasReservados = Convert.ToInt32(Console.ReadLine());
// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados);

try
{
	reserva.CadastrarSuite(suite);
	reserva.CadastrarHospedes(hospedes, suite);

	// Exibe a quantidade de hóspedes e o valor da diária
	Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
	Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria(suite,diasReservados).ToString("C2")}");
}
catch(Exception ex)
{
	Console.WriteLine(ex.Message);
	goto SelecionarSuite;
}
