using Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ServiceModels
{
    public class PersonServiceModel
    {

        # region [Select All]
        public List<Person> SelectAll()
        {
            using (var context = new ProjectDbContext())
            {
                try
                {
                    var persons = context.Person.ToList();
                    return persons;
                }
                catch (Exception)
                {

                    throw;
                }
                finally { }
            }
        }
        #endregion


        #region [Insert]
        public void Insert(Person person)
        {
            using (var context = new ProjectDbContext())
            {
                try
                {
                    context.Person.Add(person);
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                finally { }
            }
        }
        #endregion


        #region [Delete]
        public void Delete(List<Person> Persons)
        {
            using (var context = new ProjectDbContext())
            {
                try
                {
                    foreach (var person in Persons)
                    {
                        var TempPerson = context.Person.Find(person.Id);
                        context.Person.Remove(TempPerson);

                    }
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                finally { }
            }
        }
        #endregion


        #region [Update]
        public void Update(Person OldPerson,Person NewPerson)
        {
            using (var context = new ProjectDbContext())
            {
                try
                {
                    NewPerson.Id = OldPerson.Id;
                    context.Person.Remove(OldPerson);
                    context.Person.Add(NewPerson);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally { }
            }
        }
        #endregion


    }
}
