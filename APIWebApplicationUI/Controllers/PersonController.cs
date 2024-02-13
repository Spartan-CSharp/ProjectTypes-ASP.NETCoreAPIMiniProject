using System.Collections.Generic;

using ClassLibrary;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebApplicationUI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly PersonModel _person;

		public PersonController(PersonModel person)
		{
			_person = person;
		}

		// GET: api/Person
		[HttpGet]
		public IEnumerable<PersonModel> Get()
		{
			List<PersonModel> people = new List<PersonModel>();
			if ( !string.IsNullOrWhiteSpace(_person.FirstName) && !string.IsNullOrWhiteSpace(_person.LastName) )
			{
				people.Add(_person);
			}

			return people;
		}

		// GET api/Person/5
		[HttpGet("{id}")]
		public PersonModel Get(int id)
		{
			return _person;
		}

		// POST api/Person
		[HttpPost]
		public void Post([FromBody] PersonModel value)
		{
			_person.FirstName = value.FirstName;
			_person.LastName = value.LastName;
			_person.IsActive = value.IsActive;
			_person.Addresses = value.Addresses;
		}

		// PUT api/Person/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] PersonModel value)
		{
			_person.FirstName = value.FirstName;
			_person.LastName = value.LastName;
			_person.IsActive = value.IsActive;
			_person.Addresses = value.Addresses;
		}

		// DELETE api/<PersonController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_person.FirstName = "";
			_person.LastName = "";
			_person.IsActive = false;
			_person.Addresses.Clear();
		}
	}
}
