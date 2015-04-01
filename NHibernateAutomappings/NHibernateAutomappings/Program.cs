using System;
using Model.NHibernateAutomappings;

namespace NHibernateAutomappings
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = null;
            Project project = null;
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        user = new User
                        {
                            Name = "John",
                            Surname = "Kowalski"
                        };
                        session.SaveOrUpdate(user);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                    }
                }
            }

            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        project = new Project
                        {
                            Name = "John",
                            User = user
                        };
                        session.SaveOrUpdate(project);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                    }
                }
            }

            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var task = new Task
                        {
                            Name = "John",
                            Project = project
                        };
                        session.SaveOrUpdate(task);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var tasks = session.QueryOver<Task>().List();
                        foreach (var dbTask in tasks)
                        {
                            Console.WriteLine("{0} {1} {2}", dbTask.Id, dbTask.Name, dbTask.Project.Name);
                        }
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
