using BTP.Test.JBP.BackEnd.Entities;
using BTP.Test.JBP.FrontEnd.Client.Business;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BTP.Test.JBP.FrontEnd.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("**********MENU************");
                Console.WriteLine("Presiona 1 para Menú Etudiantes");
                Console.WriteLine("Presiona 2 para Menú Asignaturas");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        Console.WriteLine("Escogió Estudiantes");
                        GetStudentMenu();
                        break;
                    case "2":
                        Console.WriteLine("Escogió Asignaturas");
                        GetAssignmentsMenu();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al realizar la petición {ex.Message}");
            }

        }

        private static void GetAssignmentsMenu()

        {
            IInformationData business = new AssignmentsBO();
            BusinessManager businessManager = new BusinessManager(business);
            Dictionary<string, object> Resp = new Dictionary<string, object>();
            Console.WriteLine("**********MENU************");
            Console.WriteLine("Presiona 1 para Obtener una Asignatura");
            Console.WriteLine("Presiona 2 para Obtener todas las Asignaturas");
            Console.WriteLine("Presiona 3 para Insertar una Asignatura");
            Console.WriteLine("Presiona 4 para Actualizar una Asignatura");
            Console.WriteLine("Presiona 5 para Eliminar una Asignatura");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.WriteLine("Ingresa el Id del la Asignatura");
                    string Id = Console.ReadLine();
                    Resp = businessManager.Get(int.Parse(Id));
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "2":
                    Resp = businessManager.GetAll();
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "3":
                    Console.WriteLine("Ingresa el Nombre del la Asignatura");
                    string Nombre = Console.ReadLine();
                    Assignments assignments = new Assignments() { Name = Nombre };
                    businessManager.Insert(assignments);
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "4":
                    Console.WriteLine("Ingresa el id de la Asignatura");
                    string Idd = Console.ReadLine();
                    Console.WriteLine("Ingresa el nuevo nombre de la Asignatura");
                    string Name = Console.ReadLine();
                    Assignments assignmentss = new Assignments() { ID = int.Parse(Idd), Name = Name };
                    businessManager.Update(assignmentss);
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "5":
                    Console.WriteLine("Ingresa el id de la Asignatura a borrar");
                    string Iddel = Console.ReadLine();
                    businessManager.Delete(int.Parse(Iddel));
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;

            }

        }

        private static void GetStudentMenu()

        {
            IInformationData business = new StudentsBO();
            BusinessManager businessManager = new BusinessManager(business);
            Dictionary<string, object> Resp = new Dictionary<string, object>();
            Console.WriteLine("**********MENU************");
            Console.WriteLine("Presiona 1 para Obtener un Estudiante");
            Console.WriteLine("Presiona 2 para Obtener todos los Estudiantes");
            Console.WriteLine("Presiona 3 para Insertar un Estudiante");
            Console.WriteLine("Presiona 4 para Actualizar un Estudiante");
            Console.WriteLine("Presiona 5 para Eliminar un Estudiante");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.WriteLine("Ingresa el Id del Estudiante");
                    string Id = Console.ReadLine();
                    Resp = businessManager.Get(int.Parse(Id));
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "2":
                    Resp = businessManager.GetAll();
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "3":
                    Console.WriteLine("Ingresa el Nombre del Estudiante");
                    string Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa el Fecha de nacimiento del Estudiante (dd/mm/aaaa)");
                    string BithDate = Console.ReadLine();
                    Students assignments = new Students() { Name = Nombre, BirthDate = DateTime.Parse(BithDate) };
                    businessManager.Insert(assignments);
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "4":
                    Console.WriteLine("Ingresa el id del Estudiante");
                    string Idd = Console.ReadLine();
                    Console.WriteLine("Ingresa el nuevo nombre del estudiante");
                    string Name = Console.ReadLine();
                    Students assignmentss = new Students() { ID = int.Parse(Idd), Name = Name };
                    businessManager.Update(assignmentss);
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                case "5":
                    Console.WriteLine("Ingresa el id de la Asignatura a borrar");
                    string Iddel = Console.ReadLine();
                    businessManager.Delete(int.Parse(Iddel));
                    Console.WriteLine(JsonConvert.SerializeObject(Resp));
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;

            }

        }
    }
}
