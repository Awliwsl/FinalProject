using ApplicationService.Dtos.PersonDtos;
using Model.DomainModels;
using Model.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Services
{

    
    public class PersonApplicationService
    {
        #region [- PrivateFields -]
        private readonly PersonServiceModel _personServiceModel;
        #endregion

        #region [- Ctor -]
        public PersonApplicationService()
        {
            _personServiceModel = new PersonServiceModel();
        }
        #endregion

        #region [- GetAll() -]
        public List<GetPersonDto> GetAll()
        {
            var persons = _personServiceModel.SelectAll();
            var GetPersonDtos = new List<GetPersonDto>();
            foreach (var person in persons)
            {
                var GetPersonDto = new GetPersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                };
                GetPersonDtos.Add (GetPersonDto);

            }
            return GetPersonDtos;
        }
        #endregion

        #region [- Post() -]
        public void Post(PostPersonDto postPersonDto)
        {
            var Person = new Person()
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName
            };
            _personServiceModel.Insert(Person);
            
        }
        #endregion

        #region [- Delete() -]
        public void Delete(List<DeletePersonDto> ListOfDelete)
        {
            var Persons = new List<Person>();

            foreach (var item in ListOfDelete)
            {
                Person person = new Person();

                person.Id = item.Id;

                Persons.Add(person);
            }

            _personServiceModel.Delete(Persons);
        }
        #endregion

        #region [- Put() -]
        public void Put(PutPersonDto OldPersonDto,PutPersonDto NewPersonDto)
        {
            Person OldPerson = new Person()
            {
                Id = OldPersonDto.Id,
                FirstName = OldPersonDto.FirstName,
                LastName = OldPersonDto.LastName
            };


            Person NewPerson = new Person()
            {
                Id= NewPersonDto.Id,
                FirstName= NewPersonDto.FirstName,
                LastName= NewPersonDto.LastName
            };

            _personServiceModel.Update(OldPerson,NewPerson);
        }
        #endregion



    }
}
