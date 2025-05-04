using System;
using System.Collections.Generic;

// Classe base que representa qualquer funcionário
public abstract class Funcionario
{
    public string Nome;
    public int Idade;
    public string Cargo;
    public decimal Salario;
    public string FormaPagamento;
    public string MetodoEntregaPagamento;

    // Cada tipo de funcionário calcula o salário de um jeito
    public abstract decimal CalcularSalario();

    // Cálculo dos impostos, que podem mudar conforme o cargo
    public virtual decimal CalcularImpostos()
    {
        if (Cargo.ToLower() == "gerente")
            return Salario * 0.275m;
        else if (Cargo.ToLower() == "desenvolvedor")
            return Salario * 0.10m;
        else
            return 0;
    }

    // Entrega do pagamento, pode variar conforme o tipo
    public virtual void EntregarPagamento()
    {
        Console.WriteLine($"Pagamento de {Nome} será feito por {FormaPagamento}, entrega: {MetodoEntregaPagamento}");
    }
}

// Gerente tem bônus
public class Gerente : Funcionario
{
    public decimal Bonus;

    public override decimal CalcularSalario()
    {
        return Salario + Bonus;
    }

    public override void EntregarPagamento()
    {
        Console.WriteLine($"O gerente {Nome} vai receber R${CalcularSalario() - CalcularImpostos():0.00} via {FormaPagamento} - {MetodoEntregaPagamento}");
    }
}

// Desenvolvedor ganha por hora extra
public class Desenvolvedor : Funcionario
{
    public int HorasExtras;
    public decimal ValorHoraExtra;

    public override decimal CalcularSalario()
    {
        return Salario + (HorasExtras * ValorHoraExtra);
    }

    public override void EntregarPagamento()
    {
        Console.WriteLine($"O dev {Nome} vai receber R${CalcularSalario() - CalcularImpostos():0.00} por {FormaPagamento} - {MetodoEntregaPagamento}");
    }
}

// Estagiário só recebe o básico (e sem impostos)
public class Estagiario : Funcionario
{
    public override decimal CalcularSalario()
    {
        return Salario;
    }

    public override void EntregarPagamento()
    {
        Console.WriteLine($"Estagiário {Nome} vai receber R${Salario:0.00} via {FormaPagamento} - {MetodoEntregaPagamento}");
    }
}

class Program
{
    // Lista onde ficam todos os funcionários cadastrados
    static List<Funcionario> funcionarios = new List<Funcionario>();

    static void Main()
    {
        int escolha = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Funcionários ===");
            Console.WriteLine("1 - Cadastrar novo funcionário");
            Console.WriteLine("2 - Ver todos os funcionários");
            Console.WriteLine("3 - Calcular salários e impostos");
            Console.WriteLine("4 - Entregar pagamentos");
            Console.WriteLine("5 - Excluir funcionário");
            Console.WriteLine("6 - Sair");
            Console.Write("Digite uma opção: ");

            int.TryParse(Console.ReadLine(), out escolha);
            Console.WriteLine();

            if (escolha == 1)
                Cadastrar();
            else if (escolha == 2)
                MostrarTodos();
            else if (escolha == 3)
                CalcularSalarios();
            else if (escolha == 4)
                FazerPagamentos();
            else if (escolha == 5)
                ExcluirFuncionario();
            else if (escolha != 6)
                Console.WriteLine("Opção inválida. Tente novamente.");

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();

        } while (escolha != 6);
    }

    static void Cadastrar()
    {
        Console.WriteLine("=== Cadastro de Funcionário ===");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Idade: ");
        int idade = int.Parse(Console.ReadLine());

        Console.Write("Cargo (Gerente, Desenvolvedor, Estagiário): ");
        string cargo = Console.ReadLine().Trim();

        Console.Write("Salário base: ");
        decimal salario = decimal.Parse(Console.ReadLine());

        Console.Write("Forma de Pagamento (Pix, Débito, Dinheiro): ");
        string forma = Console.ReadLine();

        Console.Write("Método de Entrega (Automático, Manual): ");
        string entrega = Console.ReadLine();

        Funcionario novo = null;

        if (cargo.ToLower() == "gerente")
        {
            Console.Write("Bônus: ");
            decimal bonus = decimal.Parse(Console.ReadLine());

            novo = new Gerente
            {
                Nome = nome,
                Idade = idade,
                Cargo = cargo,
                Salario = salario,
                FormaPagamento = forma,
                MetodoEntregaPagamento = entrega,
                Bonus = bonus
            };
        }
        else if (cargo.ToLower() == "desenvolvedor")
        {
            Console.Write("Horas extras: ");
            int horas = int.Parse(Console.ReadLine());

            Console.Write("Valor por hora extra: ");
            decimal valorHora = decimal.Parse(Console.ReadLine());

            novo = new Desenvolvedor
            {
                Nome = nome,
                Idade = idade,
                Cargo = cargo,
                Salario = salario,
                FormaPagamento = forma,
                MetodoEntregaPagamento = entrega,
                HorasExtras = horas,
                ValorHoraExtra = valorHora
            };
        }
        else if (cargo.ToLower() == "estagiário")
        {
            novo = new Estagiario
            {
                Nome = nome,
                Idade = idade,
                Cargo = cargo,
                Salario = salario,
                FormaPagamento = forma,
                MetodoEntregaPagamento = entrega
            };
        }
        else
        {
            Console.WriteLine("Cargo inválido. Cadastro cancelado.");
            return;
        }

        funcionarios.Add(novo);
        Console.WriteLine("Funcionário cadastrado com sucesso!");
    }

    static void MostrarTodos()
    {
        Console.WriteLine("=== Lista de Funcionários ===");

        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado ainda.");
            return;
        }

        for (int i = 0; i < funcionarios.Count; i++)
        {
            var f = funcionarios[i];
            Console.WriteLine($"{i + 1}. Nome: {f.Nome}, Cargo: {f.Cargo}, Salário Base: R${f.Salario:0.00}");
        }
    }

    static void CalcularSalarios()
    {
        Console.WriteLine("=== Cálculo de Salários ===");

        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário para calcular.");
            return;
        }

        foreach (var f in funcionarios)
        {
            var bruto = f.CalcularSalario();
            var imposto = f.CalcularImpostos();
            var liquido = bruto - imposto;

            Console.WriteLine($"{f.Nome} ({f.Cargo}): Bruto: R${bruto:0.00} | Imposto: R${imposto:0.00} | Líquido: R${liquido:0.00}");
        }
    }

    static void FazerPagamentos()
    {
        Console.WriteLine("=== Entrega de Pagamentos ===");

        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário para pagar.");
            return;
        }

        foreach (var f in funcionarios)
        {
            f.EntregarPagamento();
        }
    }

    static void ExcluirFuncionario()
    {
        Console.WriteLine("=== Excluir Funcionário ===");

        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Não há funcionários para excluir.");
            return;
        }

        MostrarTodos();
        Console.Write("\nDigite o número do funcionário que deseja remover: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= funcionarios.Count)
        {
            var f = funcionarios[idx - 1];
            funcionarios.RemoveAt(idx - 1);
            Console.WriteLine($"Funcionário {f.Nome} removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Número inválido. Operação cancelada.");
        }
    }
}
