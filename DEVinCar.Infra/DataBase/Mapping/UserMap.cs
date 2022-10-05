
using DEVinCar.Domain.Enums;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.DataBase.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder
                .Property(u => u.Email)
                    .HasMaxLength(150)
                    .IsRequired();

            builder
                 .Property(u => u.Password)
                        .HasMaxLength(50)
                        .IsRequired();

            builder
                 .Property(u => u.Name)
                        .HasMaxLength(255)
                        .IsRequired();

            builder
                 .Property(u => u.Role)
                        .HasMaxLength(255)
                        .IsRequired();

            builder
                .Property(u => u.BirthDate);
            builder
                         .HasData(new[] {
                    new User(1, "jose@email.com", "123456", "Jose", new DateTime(2000, 12, 10),Permissoes.Gerente),
                    new User(2, "andrea@email.com", "123456", "Andrea", new DateTime(1999, 05, 11),Permissoes.Comprador),
                    new User(3, "adao@email.com", "123456", "Adao", new DateTime(2005, 09, 02),Permissoes.Vendedor),
                    new User(4, "monique@email.com", "123456", "Monique", new DateTime(2001, 06, 07),Permissoes.Vendedor),
                             });


        }
    }

}
