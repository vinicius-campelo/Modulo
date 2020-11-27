using MVC.MODULO.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC.MODULO.UI.Data
{
    /// <summary>
    /// Inicializar o BD com os dados de teste. Você pode especificar que isso deve ser feito toda vez que seu aplicativo for executado ou somente quando o modelo estiver fora de sincronia com o banco de dados existente.
    /// </summary>
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<MVCModuloDataContext>
    {
        // CreateDatabaseIfNotExists Faz com que um banco de dados seja criado quando necessário e carregue os dados de teste no novo banco de dado.

        /// <summary>
        /// Método Seed será executado quando o banco de dados for recriado e recriará os dado de teste.
        /// Método usa esse objeto para adicionar novas entidades ao banco de dados
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MVCModuloDataContext context)
        {
            var atividades = new List<Atividade>() 
            {
                new Atividade() { Tarefa="Jogar Bola", Descricao="Jogar Bola com os Amigos Final de Semana", Data=DateTime.Now, Prioridade="Media", Status=true },
                new Atividade() { Tarefa="Sair", Descricao="Sair com as Crianças Final de Semana", Data=DateTime.Now, Prioridade="Alta", Status=false },
                new Atividade() { Tarefa="Estudar", Descricao="Estudar terça-feira a tarde", Data=DateTime.Now, Prioridade="Alta", Status=true },
                new Atividade() { Tarefa="Trabalhar", Descricao="Trabalhar quarta-feira dia inteiro", Data=DateTime.Now, Prioridade="Baixa", Status=false },
            };
            context.Atividades.AddRange(atividades);
            context.SaveChanges();//Salva os dados no DB
        }
    }
}