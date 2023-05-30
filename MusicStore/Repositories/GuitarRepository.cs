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
               SELECT p.Id, p.Title, p.Content, p.ImageLocation, p.CreateDateTime, p.PublishDateTime,
                      p.IsApproved, p.UserProfileId, p.CategoryId,

                      up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime AS UserProfileDateCreated,
                      up.ImageLocation AS UserProfileImageUrl, up.UserTypeId
                        
                 FROM Post p
                      JOIN UserProfile up ON p.UserProfileId = up.Id
                WHERE PublishDateTime <= SYSDATETIME() AND IsApproved = 1
             ORDER BY PublishDateTime DESC
            "
                    ;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var guitars = new List<Guitar>();
                        while (reader.Read())
                        {
                            guitars.Add(new Guitar()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Title = DbUtils.GetString(reader, "Title"),
                                Content = DbUtils.GetString(reader, "Content"),
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                PublishDateTime = DbUtils.GetDateTime(reader, "PublishDatetime"),
                                IsApproved = (bool)reader["IsApproved"],
                                CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FireBaseUserId"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
                                    ImageLocation = DbUtils.GetString(reader, "UserProfileImageUrl"),
                                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
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
            
            SELECT p.Title, p.Content, p.ImageLocation, p.CreateDateTime, p.PublishDateTime,
                      p.IsApproved, p.UserProfileId, p.CategoryId,

                      up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime AS UserProfileDateCreated,
                      up.ImageLocation AS UserProfileImageUrl, up.UserTypeId
            FROM Post p
                      JOIN UserProfile up ON p.UserProfileId = up.Id
                WHERE p.Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        Guitar guitar = null;
                        if (reader.Read())
                        {
                            guitar = new Guitar()
                            {
                                Title = DbUtils.GetString(reader, "Title"),
                                Content = DbUtils.GetString(reader, "Content"),
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                PublishDateTime = DbUtils.GetDateTime(reader, "PublishDatetime"),
                                IsApproved = (bool)reader["IsApproved"],
                                CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FireBaseUserId"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
                                    ImageLocation = DbUtils.GetString(reader, "UserProfileImageUrl"),
                                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                },
                            };
                        }
                        return guitar;
                    }
                }
            }
        }

        public List<Guitar> GetByUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
               SELECT p.Id, p.Title, p.Content, p.ImageLocation, p.CreateDateTime, p.PublishDateTime,
                      p.IsApproved, p.UserProfileId, p.CategoryId,

                      up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime AS UserProfileDateCreated,
                      up.ImageLocation AS UserProfileImageUrl, up.UserTypeId
                        
                 FROM Post p
                      JOIN UserProfile up ON p.UserProfileId = up.Id
                WHERE PublishDateTime <= SYSDATETIME() AND IsApproved = 1 AND up.FireBaseUserId = @firebaseUserId
             ORDER BY PublishDateTime DESC
            ";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var guitars = new List<Guitar>();
                        while (reader.Read())
                        {
                            guitars.Add(new Guitar()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Title = DbUtils.GetString(reader, "Title"),
                                Content = DbUtils.GetString(reader, "Content"),
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                PublishDateTime = DbUtils.GetDateTime(reader, "PublishDatetime"),
                                IsApproved = (bool)reader["IsApproved"],
                                CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FireBaseUserId"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
                                    ImageLocation = DbUtils.GetString(reader, "UserProfileImageUrl"),
                                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                },
                            });
                        }

                        return guitars;
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
                        INSERT INTO Post (
                        Title,
                        Content,
                        ImageLocation,
                        CreateDateTime,
                        PublishDateTime,
                        IsApproved,
                        CategoryId,
                        UserProfileId
                        )
                        
                        OUTPUT INSERTED.ID
	                    
                        VALUES (
                        @Title,
                        @Content,
                        @ImageLocation,
                        @CreateDateTime,
                        @PublishDateTime,
                        @IsApproved,
                        @CategoryId,
                        @UserProfileId)
                    ";

                    DbUtils.AddParameter(cmd, "@Title", post.Title);
                    DbUtils.AddParameter(cmd, "@Content", post.Content);
                    DbUtils.AddParameter(cmd, "@ImageLocation", post.ImageLocation);
                    DbUtils.AddParameter(cmd, "@CreateDateTime", post.CreateDateTime);
                    DbUtils.AddParameter(cmd, "@PublishDateTime", post.PublishDateTime);
                    DbUtils.AddParameter(cmd, "@IsApproved", true);
                    DbUtils.AddParameter(cmd, "@CategoryId", post.CategoryId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", post.UserProfileId);

                    guitar.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}

