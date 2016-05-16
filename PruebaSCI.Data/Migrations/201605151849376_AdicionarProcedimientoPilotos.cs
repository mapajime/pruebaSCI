using System.IO;

namespace PruebaSCI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AdicionarProcedimientoPilotos : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("dbo.SPRealizarCambiosPilotos",
                p =>
                new
                {
                    IdAccion = p.Int(),
                    Id = p.Guid(),
                    Nombre =p.String(),
                    Numero = p.Int(),
                    FechaNacimiento = p.DateTime(),
                    Equipo = p.Guid(),
                    Nacionalidad =p.Guid()
                },
                body: @"if @IdAccion = 1 
	                        begin
	                        UPDATE [dbo].[Pilotos]
                           SET 
                              [Nombre] = @Nombre
                              ,[NumeroCarro] = @Numero
                              ,[FechaNacimiento] = @FechaNacimiento
                              ,[Equipo_Id] = @Equipo
                              ,[Nacionalidad_Id] = @Nacionalidad
                         WHERE Id= @Id
                         end
                         else if @IdAccion = 2 
                         begin

                            DELETE FROM [dbo].[Pilotos]
                              WHERE Id = @Id
                        end	   
                        else if @IdAccion =3
                        begin
    
	                        INSERT INTO [dbo].[Pilotos]
                                   ([Id]
                                   ,[Nombre]
                                   ,[NumeroCarro]
                                   ,[FechaNacimiento]
                                   ,[Equipo_Id]
                                   ,[Nacionalidad_Id])
                             VALUES
                                   ( @Id
                                   , @Nombre
                                   , @Numero
                                   , @FechaNacimiento
                                   , @Equipo
		                           , @Nacionalidad)
                        end
                        else if @IdAccion =4
                        begin

                        SELECT [Id]
                              ,[Nombre]
                              ,[NumeroCarro]
                              ,[FechaNacimiento]
                              ,[Equipo_Id]
                              ,[Nacionalidad_Id]
                          FROM [dbo].[Pilotos]


                        end
                        else if @IdAccion =5
                        begin

                        SELECT [Id]
                              ,[Nombre]
                              ,[NumeroCarro]
                              ,[FechaNacimiento]
                              ,[Equipo_Id]
                              ,[Nacionalidad_Id]
                          FROM [dbo].[Pilotos]
                          WHERE Id = @Id

                        end");
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.SPRealizarCambiosPilotos");
        }
    }
}
