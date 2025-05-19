using System;
using System.Collections.Generic;

namespace CasaInteligente
{
    class Comodo
    {
        public string Nome;
        public bool Presenca;
        public bool LuzLigada;
        public bool ArCondicionadoLigado;
        public bool TvLigada;
        public bool MicroOndasLigado;
        public bool BombaLigada;
        public bool AquecedorLigado;

        public Comodo(string nome)
        {
            Nome = nome;
            Presenca = false;
            LuzLigada = true;
            ArCondicionadoLigado = false;
            TvLigada = false;
            MicroOndasLigado = false;
            BombaLigada = false;
            AquecedorLigado = false;
        }
    }

    class Program
    {
        static bool TemPresenca(Comodo c)
        {
            return c.Presenca;
        }

        static void DesligarLuz(Comodo c)
        {
            c.LuzLigada = false;
            Console.WriteLine("Luz desligada no " + c.Nome);
        }

        static void DesligarArCondicionado(Comodo c)
        {
            if (c.ArCondicionadoLigado)
            {
                c.ArCondicionadoLigado = false;
                Console.WriteLine("Ar-condicionado desligado no " + c.Nome);
            }
        }

        static void DesligarTv(Comodo c)
        {
            if (c.TvLigada)
            {
                c.TvLigada = false;
                Console.WriteLine("TV desligada no " + c.Nome);
            }
        }

        static void DesligarMicroOndas(Comodo c)
        {
            if (c.MicroOndasLigado)
            {
                c.MicroOndasLigado = false;
                Console.WriteLine("Micro-ondas desligado na " + c.Nome);
            }
        }

        static void DesligarBomba(Comodo c)
        {
            if (c.BombaLigada)
            {
                c.BombaLigada = false;
                Console.WriteLine("Bomba desligada na " + c.Nome);
            }
        }

        static void DesligarAquecedor(Comodo c)
        {
            if (c.AquecedorLigado)
            {
                c.AquecedorLigado = false;
                Console.WriteLine("Aquecedor desligado na " + c.Nome);
            }
        }

        static void VerificarEDesligar(Comodo c)
        {
            if (!TemPresenca(c))
            {
                DesligarLuz(c);
                DesligarArCondicionado(c);
                DesligarTv(c);
                DesligarMicroOndas(c);
                DesligarBomba(c);
                DesligarAquecedor(c);
            }
            else
            {
                Console.WriteLine("Há presença no " + c.Nome + ". Nada foi desligado.");
            }
        }

        static void Main(string[] args)
        {
            List<Comodo> comodos = new List<Comodo>();

            Comodo quarto1 = new Comodo("Quarto 1");
            quarto1.ArCondicionadoLigado = true;
            quarto1.TvLigada = true;

            Comodo quarto2 = new Comodo("Quarto 2");
            quarto2.ArCondicionadoLigado = true;
            quarto2.TvLigada = true;

            Comodo sala = new Comodo("Sala");
            sala.ArCondicionadoLigado = true;
            sala.TvLigada = true;

            Comodo cozinha = new Comodo("Cozinha");
            cozinha.ArCondicionadoLigado = true;
            cozinha.MicroOndasLigado = true;

            Comodo piscina = new Comodo("Piscina");
            piscina.BombaLigada = true;
            piscina.AquecedorLigado = true;

            // Simulando presença
            quarto1.Presenca = false;
            quarto2.Presenca = true;
            sala.Presenca = false;
            cozinha.Presenca = false;
            piscina.Presenca = true;

            comodos.Add(quarto1);
            comodos.Add(quarto2);
            comodos.Add(sala);
            comodos.Add(cozinha);
            comodos.Add(piscina);

            foreach (Comodo c in comodos)
            {
                VerificarEDesligar(c);
            }

            Console.WriteLine("Verificação finalizada.");
        }
    }
}
