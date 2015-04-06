using System;
using System.Data;
using Model.NHibernateEventListener;

namespace NHibernateEventListener
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var user = new User
                        {
                            Name = "Jhon",
                            Surname = "Kowalski"
                        };
                        session.SaveOrUpdate(user);
                        var project = new Project
                        {
                            Name = "Project",
                            User = user
                        };
                        session.SaveOrUpdate(project);
                        var firstTask = new Task
                        {
                            Name = "First task",
                            Project = project
                        };

                        session.SaveOrUpdate(firstTask);
                        transaction.Commit();

                        Console.WriteLine("Project created {0} modofied {1}", project.CreationDate,
                            project.ModificationDate);
                        Console.WriteLine("Task created {0} modofied {1}", firstTask.CreationDate,
                            firstTask.ModificationDate);
                        Console.WriteLine("User created {0} modofied {1}", user.CreationDate,
                            user.ModificationDate);
                        Console.ReadKey();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        session.Close();
                    }
                }
            }
        }
    }
}
