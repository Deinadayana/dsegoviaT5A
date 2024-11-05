using dsegoviaS5A.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dsegoviaS5A.Utils
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; private set; }

        private void Init()
        {
            if (conn != null) return;

            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository(string path)
        {
            dbPath = path;
            Init(); // Mover la inicialización aquí
        }

        public void AddNewPerson(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Nombre es un campo requerido");
                }

                Persona person = new() { Name = name };
                int result = conn.Insert(person);
                StatusMessage = result > 0 ? "Dato insertado" : "Error al insertar dato";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return new List<Persona>();
            }
        }

        public void UpdatePerson(int id, string name)
        {
            try
            {
                Init();
                var personToUpdate = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (personToUpdate == null)
                {
                    StatusMessage = "Persona no encontrada.";
                    return;
                }

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es un campo requerido");

                personToUpdate.Name = name;
                conn.Update(personToUpdate);
                StatusMessage = "Dato actualizado";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var personToDelete = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (personToDelete == null)
                {
                    StatusMessage = "Persona no encontrada.";
                    return;
                }

                conn.Delete(personToDelete);
                StatusMessage = "Dato eliminado";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

    }
}

