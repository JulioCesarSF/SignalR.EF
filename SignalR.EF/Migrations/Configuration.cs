namespace SignalR.EF.Migrations
{
    using SignalR.EF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalR.EF.DAL.BancoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SignalR.EF.DAL.BancoContext";
        }

        protected override void Seed(SignalR.EF.DAL.BancoContext context)
        {
            List<Produto> lista = new List<Produto>();
            lista.Add(new Produto()
            {
                Nome = "Bola",
                Valor = 99.9M
            });
            lista.Add(new Produto()
            {
                Nome = "Livro",
                Valor = 199.89M
            });
            lista.Add(new Produto()
            {
                Nome = "Computador",
                Valor = 5612.45M
            });

            lista.ForEach(p => context.Produtos.AddOrUpdate(p));

            context.SaveChanges();
        }
    }
}
