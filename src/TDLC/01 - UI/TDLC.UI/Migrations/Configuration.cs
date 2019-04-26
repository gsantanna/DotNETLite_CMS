namespace TDLC.UI.Migrations
{
    using Areas.Admin.Models.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TDLC.UI.Areas.Admin.Models.Identity.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {


            var manager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(
                new ApplicationDbContext()));

            

            var usuarios = new[] {
                new { Nome = "Carolina Pederneiras"  , Email = "carolina@antonelliadv.com.br"},
                new { Nome = "Suzana de Lima"  , Email = "lima@antonelliadv.com.br"},
                new { Nome = "Raphael Teixeira"  , Email = " teixeira@antonelliadv.com.br"},
                new { Nome = "Marcos Orlandi"  , Email = "orlandi@antonelliadv.com.br"},
                new { Nome = "Antonio Xavier"  , Email = "antonio.xavier@thdcriativa.com.br"}

            };



            foreach (var item in usuarios)
            {
                if (manager.FindByEmail(item.Email) == null)
                {
                    var usuario = new ApplicationUser();
                    usuario.UserName = item.Email;
                    usuario.Nome = item.Nome;
                    usuario.PhoneNumberConfirmed = true;
                    usuario.PhoneNumber = "9999";
                    usuario.Email = item.Email;
                    usuario.EmailConfirmed = true;
                    manager.Create(usuario, "P@ssw0rd");
                }
            }



            






        }
    }
}
