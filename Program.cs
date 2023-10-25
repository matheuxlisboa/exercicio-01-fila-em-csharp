using System;
using System.Collections.Generic;
using System.Threading;

class Cliente
{
    public int Numero { get; set; }
    public int TempoAtendimento { get; set; }
}

class Funcionario
{
    public int Numero { get; set; }
    public bool Ocupado { get; set; }
}

public class Program
{
    static void Main()
    {
        int numeroClientes = 10;
        int numeroFuncionarios = 3;

        Queue<Cliente> filaEspera = new Queue<Cliente>();
        for (int i = 1; i <= numeroClientes; i++)
        {
            Cliente cliente = new Cliente
            {
                Numero = i,
                TempoAtendimento = new Random().Next(1, 6)
            };
            filaEspera.Enqueue(cliente);
            Console.WriteLine($"Cliente {i} entrou na fila de espera.");
        }

        List<Funcionario> funcionarios = new List<Funcionario>();
        for (int i = 1; i <= numeroFuncionarios; i++)
        {
            funcionarios.Add(new Funcionario { Numero = i, Ocupado = false });
        }

        while (filaEspera.Count > 0)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (!funcionarios[i].Ocupado && filaEspera.Count > 0)
                {
                    Cliente cliente = filaEspera.Dequeue();
                    funcionarios[i].Ocupado = true;
                    Console.WriteLine($"\nAtendendo Cliente {cliente.Numero}...");
                    Thread.Sleep(cliente.TempoAtendimento * 1000);
                    Console.WriteLine($"Cliente {cliente.Numero} atendido pelo funcionário: {funcionarios[i].Numero} com o tempo de {cliente.TempoAtendimento} segundos.");
                    funcionarios[i].Ocupado = false;
                }
            }
        }

        Console.WriteLine("\nTodos os clientes foram atendidos.");
    }
}