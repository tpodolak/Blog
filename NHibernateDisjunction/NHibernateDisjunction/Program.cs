using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model.NHibernateAutomappings;
using NHibernate.Criterion;
using NHibernateAutomappings;

namespace NHibernateDisjunction
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareData();
            GetDataUsingDisjunction();
            GetDataUsingOrRestriction();
            GetDataUsingIsInExtension();
        }

        private static void GetDataUsingDisjunction()
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {

                        var disjunctinos = Restrictions.Disjunction()
                            .Add(Restrictions.Where<Task>(val => val.Name == "First task"))
                            .Add(Restrictions.On<Task>(val => val.Id).IsIn(new[] { 1, 2, 3 }));

                        var result = session.QueryOver<Task>().Where(disjunctinos).List();

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

        private static void GetDataUsingOrRestriction()
        {

            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {

                        var orRestriction = Restrictions.Or(
                            Restrictions.Where<Task>(val => val.Name == "First task"),
                            Restrictions.On<Task>(val => val.Id).IsIn(new[] { 1, 2, 3 }));

                        var result = session.QueryOver<Task>().Where(orRestriction).List();

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

        private static void GetDataUsingIsInExtension()
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var result =
                            session.QueryOver<Task>()
                                   .Where(val => val.Name == "First task" || val.Id.IsIn(new[] { 1, 2, 3 }))
                                   .List();

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

        private static void PrepareData()
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
                        var secondTask = new Task
                        {
                            Name = "Second task",
                            Project = project
                        };
                        session.SaveOrUpdate(firstTask);
                        session.SaveOrUpdate(secondTask);
                        transaction.Commit();
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
