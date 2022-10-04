using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace PLinqFuncao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Declarações
            List<Aeronave> lstAero = new List<Aeronave>();
            List<Companhia> lstComp = new List<Companhia>();

            lstAero.Add(new Aeronave { ID = 1, Inscricao = "PT-LSD", Capacidade = 10 });
            lstAero.Add(new Aeronave { ID = 2, Inscricao = "PL-BRA", Capacidade = 20 });

            lstComp.Add(new Companhia { ID = 1, Nome = "Unicórnios Coloridos" });
            lstComp.Add(new Companhia { ID = 2, Nome = "Dragões Flamejantes" });
            #endregion

            #region foreach
            Console.WriteLine("Impressão utilizando foreach");
            foreach (var item in lstAero) Console.WriteLine(item);

            foreach (var item in lstComp) Console.WriteLine(item);

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region ForEach
            Console.WriteLine("Impressão utilizando ForEach");
            lstAero.ForEach(item => Console.WriteLine(item.ToString()));
            lstComp.ForEach(item => Console.WriteLine(item.ToString()));

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region SELECT sem WHERE

            Console.WriteLine("Impressão utilizando SELECT sem WHERE, anônimo");

            var itemAeronave = from aeronave in lstAero
                               select new
                               { //Utilizando string do tipo anônimo, para usar apenas oq interessa
                                   Inscricao = aeronave.Inscricao,
                                   aeronave.Capacidade
                               };
            // SELECT : projeção do objeto da lista

            foreach (var item in itemAeronave)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();

            #endregion

            #region SELECT sem WHERE

            Console.WriteLine("Impressão utilizando SELECT sem WHERE, classe");

            var itemAero = from aeronave in lstAero
                           select new AeronaveDTO()
                           {
                               Inscricao = aeronave.Inscricao,
                               Capacidade = aeronave.Capacidade
                           };


            foreach (var item in itemAero)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();

            #endregion

            #region SELECT com WHERE

            Console.WriteLine("Impressão utilizando SELECT com WHERE, anônimo");

            var lisnew = from aeronave in lstAero
                         where aeronave.Capacidade > 10
                         select new
                         {
                             aeronave.Inscricao,
                             aeronave.Capacidade
                         };
            foreach (var item in lisnew)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Take (pega somente a quantidade de itens que eu defini)

            Console.WriteLine("Impressão utilizando Take");

            var paginacao = lstAero.Take(1);
            foreach (var item in paginacao)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Skip (ignora somente a quantidade de itens que eu defini)

            Console.WriteLine("Impressão utilizando skip");

            var paginacaoSkip = lstAero.Skip(1);
            foreach (var item in paginacaoSkip)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Take e Skip concatenados
            Console.WriteLine("Impressão utilizando take e skip");

            var paginacaoTS = lstAero.Skip(1).Take(2); //pula o primeiro e imprime os dois seguintes (se o número de seguintes for maior, ele não imprime nada)
            foreach (var item in paginacaoTS)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Paginação na impressão
            Console.WriteLine("Impressão utilizando paginações");
            for(int i = 0; i < lstAero.Count; i= i+1)//incremento de acordo com o número de aeronaves q vou imprimir por vez
            {
                foreach ( var aviao in lstAero.Skip(i).Take(1))
                {
                    Console.WriteLine(aviao);
                    
                }
                Console.ReadKey();
                Console.Clear();
            }
           
            #endregion


            Console.WriteLine("FIM!");

        }
        public class AeronaveDTO
        {
            public string Inscricao { get; set; }

            public int Capacidade { get; set; }

            public override string ToString()
            {
                return $"\nInscrição: {this.Inscricao}\nCapacidade:{this.Capacidade}"; //retorna minha string já formatada da maneira que eu quero
            }
        }
        public class Aeronave
        {
            public int ID { get; set; }

            public string Inscricao { get; set; }

            public int Capacidade { get; set; }

            public override string ToString()
            {
                return $"\nID: {this.ID}\nInscrição: {this.Inscricao}\nCapacidade:{this.Capacidade}"; //retorna minha string já formatada da maneira que eu quero
            }
        }
        public class Companhia
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public override string ToString()
            {
                return "\nID: " + ID + "\nNome: " + Nome;
            }
        }
    }
}
