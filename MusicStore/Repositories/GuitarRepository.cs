using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MusicStore.Repositories;
using MusicStore.Models;
using MusicStore.Utils;

namespace MusicStore.Repositories
{
    public class GuitarRepository : BaseRepository, IGuitarRepository
    {
        public GuitarRepository(IConfiguration configuration) : base(configuration) { }

        public List<Guitar> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT g.[Id], b.[Name] AS Brand, g.[Name], gt.[Name] AS 'Type', c.[Name] AS 'Category', Strings, NumFrets, Price, ImagePath, Used
                FROM Guitar g
                LEFT JOIN Brand b ON b.Id = g.BrandId
                LEFT JOIN GuitarType gt ON gt.Id = g.GuitarTypeId
                LEFT JOIN Category c ON c.Id = g.CategoryId;"
                    ;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var guitars = new List<Guitar>();
                        while (reader.Read())
                        {
                            guitars.Add(new Guitar()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                ImagePath = DbUtils.GetString(reader, "ImagePath"),
                                NumFrets = DbUtils.GetInt(reader, "NumFrets"),
                                Strings = DbUtils.GetInt(reader, "Strings"),
                                Price = DbUtils.GetDouble(reader, "Price"),
                                Used = (bool)reader["Used"],
                                Brand = new Brand()
                                {
                                    Name = DbUtils.GetString(reader, "Brand")
                                },
                                Category = new Category()
                                {
                                    Name = DbUtils.GetString(reader, "Category")
                                },
                                GuitarType = new GuitarType()
                                {
                                    Name = DbUtils.GetString(reader, "Type")
                                },
                            });
                        }

                        return guitars;
                    }
                }
            }
        }

        public Guitar GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT g.[Id], b.[Name] AS Brand, g.[Name], gt.[Name] AS 'Type', c.[Name] AS 'Category', Strings, NumFrets, Price, Used
                FROM Guitar g
                LEFT JOIN Brand b ON b.Id = g.BrandId
                LEFT JOIN GuitarType gt ON gt.Id = g.GuitarTypeId
                LEFT JOIN Category c ON c.Id = g.CategoryId
                WHERE g.Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Guitar guitar = null;
                        if (reader.Read())
                        {
                            guitar = new Guitar()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                ImagePath = DbUtils.GetString(reader, "ImagePath"),
                                NumFrets = DbUtils.GetInt(reader, "NumFrets"),
                                Strings = DbUtils.GetInt(reader, "Strings"),
                                Price = DbUtils.GetDouble(reader, "Price"),
                                Used = (bool)reader["Used"],
                                Brand = new Brand()
                                {
                                    Name = DbUtils.GetString(reader, "Brand")
                                },
                                Category = new Category()
                                {
                                    Name = DbUtils.GetString(reader, "Category")
                                },
                                GuitarType = new GuitarType()
                                {
                                    Name = DbUtils.GetString(reader, "Type")
                                },
                            };
                        }
                        return guitar;
                    }
                }
            }
        }

        public void Add(Guitar guitar)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Guitar (
                        Name,
                        BrandId,
                        GuitarTypeId,
                        CategoryId,
                        Strings,
                        NumFrets,
                        Price,
                        ImagePath,
                        Used
                        )
                        
                        OUTPUT INSERTED.ID
	                    
                        VALUES (
                        @Name,
                        @BrandId,
                        @GuitarTypeId,
                        @CategoryId,
                        @Strings,
                        @NumFrets,
                        @Price,
                        @ImagePath,
                        @Used)
                    ";

                    DbUtils.AddParameter(cmd, "@Name", guitar.Name);
                    DbUtils.AddParameter(cmd, "@BrandId", guitar.BrandId);
                    DbUtils.AddParameter(cmd, "@GuitarTypeId", guitar.GuitarTypeId);
                    DbUtils.AddParameter(cmd, "@CategoryId", guitar.CategoryId);
                    DbUtils.AddParameter(cmd, "@Strings", guitar.Strings);
                    DbUtils.AddParameter(cmd, "@NumFrets", guitar.NumFrets);
                    DbUtils.AddParameter(cmd, "@Price", guitar.Price);
                    DbUtils.AddParameter(cmd, "@ImagePath", guitar.ImagePath);
                    DbUtils.AddParameter(cmd, "@Used", 0);

                    guitar.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}

