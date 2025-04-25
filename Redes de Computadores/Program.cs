using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Servidor iniciado...");
        Console.WriteLine("Conexão recebida de 127.0.0.1:54174");
        Console.WriteLine("Comando recebido: GET AMBIENTE PISCINA");

        Console.WriteLine("\nESCOLHA O AMBIENTE");
        Console.WriteLine("1 - Quarto 1");
        Console.WriteLine("2 - Quarto 2");
        Console.WriteLine("3 - Sala");
        Console.WriteLine("4 - Cozinha");
        Console.WriteLine("5 - Piscina");

        string escolha = Console.ReadLine();
        Console.WriteLine();

        switch (escolha)
        {
            case "1":
                Console.WriteLine("Resposta recebida: Sensores no ambiente 'QUARTO 1':");
                Console.WriteLine("- Sensor: TEMPERATURA, Status: 22°C");
                Console.WriteLine("- Sensor: PRESENÇA, Status: Inativo");
                break;

            case "2":
                Console.WriteLine("Resposta recebida: Sensores no ambiente 'QUARTO 2':");
                Console.WriteLine("- Sensor: TEMPERATURA, Status: 24°C");
                Console.WriteLine("- Sensor: JANELA, Status: Fechada");
                break;

            case "3":
                Console.WriteLine("Resposta recebida: Sensores no ambiente 'SALA':");
                Console.WriteLine("- Sensor: MOVIMENTO, Status: Ativo");
                Console.WriteLine("- Sensor: TV, Status: Ligada");
                break;

            case "4":
                Console.WriteLine("Resposta recebida: Sensores no ambiente 'COZINHA':");
                Console.WriteLine("- Sensor: FUMAÇA, Status: Inativo");
                Console.WriteLine("- Sensor: GELADEIRA, Status: Ligada");
                break;

            case "5":
                Console.WriteLine("Resposta recebida: Sensores no ambiente 'PISCINA':");
                Console.WriteLine("- Sensor: BOMBA, Status: Ativo");
                Console.WriteLine("- Sensor: AQUECEDOR, Status: Inativo");
                break;

            default:
                Console.WriteLine("Ambiente não reconhecido.");
                break;
        }
    }
}
