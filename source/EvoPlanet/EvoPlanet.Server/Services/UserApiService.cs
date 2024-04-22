using EvoPlanet.Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace EvoPlanet.Server.Services
{
    public class UserApiService : IUserApiService
    {
        private const string DB_FILE_NAME = "valami.json";
        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public List<User> GetAllUsers()
        {
            try
            {
                string jsonData = DataBase.ReadData(DB_FILE_NAME);
                List<User>? users = JsonSerializer.Deserialize<List<User>>(jsonData);
                return users ?? new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return new List<User>();
            }
        }

        public void SaveData(List<User> users)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(users, _defaultJsonSerializerOptions);
                DataBase.SaveData(DB_FILE_NAME, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }

        public void AddUser(User newUser)
        {
            List<User> users = GetAllUsers();
            users.Add(newUser);
            SaveData(users);
        }

        public void UpdateUser(int userId, User updatedUser)
        {
            List<User> users = GetAllUsers();

            var existingUser = users.FirstOrDefault(u => u.UserId == userId);
            if (existingUser != null)
            {
                existingUser.UserName = updatedUser.UserName;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;
                SaveData(users);
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public void DeleteUser(int userId)
        {
            List<User> users = GetAllUsers();

            var userToDelete = users.FirstOrDefault(u => u.UserId == userId);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                SaveData(users);
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }


    }
}