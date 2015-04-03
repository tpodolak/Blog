using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Model.NHibernateAutomappings;

namespace NHibernateMultiqueries
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataUsualWay();
            GetDataWithMultiquery();
            GetDataWithMultiCriteria();
            GetDataWithFuture();
            Console.ReadKey();
        }

        private static void GetDataUsualWay()
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var projects = session.QueryOver<Project>().Where(val => val.Name == "Project").List();
                        var tasks = session.QueryOver<Task>().Where(val => val.Name == "First task").List();
                        transaction.Commit();

                    }
                    catch (Exception ex)
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

        private static void GetDataWithMultiquery()
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var projectQuery =
                            session.CreateQuery("FROM Project as prj where prj.Name= :projectName")
                                   .SetParameter("projectName", "Project");
                        var taskQuery = session.CreateQuery("FROM Task as tsk where tsk.Name=:taskName")
                                               .SetParameter("taskName", "First task");
                        var multiQueryByIndex = session.CreateMultiQuery()
                                                       .Add<Project>(projectQuery)
                                                       .Add<Task>(taskQuery);

                        var multiQueryByKey = session.CreateMultiQuery()
                                                     .Add<Project>("project", projectQuery)
                                                     .Add<Task>("task", taskQuery);

                        var result = multiQueryByIndex.List();
                        var projects = result[0] as List<Project>;
                        var tasks = result[1] as List<Task>;

                        projects = multiQueryByKey.GetResult("project") as List<Project>;
                        tasks = multiQueryByKey.GetResult("task") as List<Task>;
                        transaction.Commit();

                    }
                    catch (Exception ex)
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

        private static void GetDataWithMultiCriteria()
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var projectQuery = session.QueryOver<Project>().Where(val => val.Name == "Project");
                        var taskQuery = session.QueryOver<Task>().Where(val => val.Name == "First task");
                        var multiCriteriaByIndex = session.CreateMultiCriteria()
                                                          .Add(projectQuery)
                                                          .Add(taskQuery);

                        var multiCriteriaByKey = session.CreateMultiCriteria()
                                                        .Add("project", projectQuery)
                                                        .Add("task", taskQuery);

                        IList result = multiCriteriaByIndex.List();
                        var projects = result[0] as List<Project>;
                        var tasks = result[1] as List<Task>;

                        projects = multiCriteriaByKey.GetResult("project") as List<Project>;
                        tasks = multiCriteriaByKey.GetResult("task") as List<Task>;
                        transaction.Commit();

                    }
                    catch (Exception ex)
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

        private static void GetDataWithFuture()
        {
            using (var session = DataAccesLayer.Instance.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var projects = session.QueryOver<Project>().Where(val => val.Name == "Project").Future<Project>();
                        var tasks = session.QueryOver<Task>().Where(val => val.Name == "First task").Future<Task>();


                        foreach (var task in tasks)
                        {



                        }
                        transaction.Commit();

                    }
                    catch (Exception ex)
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
