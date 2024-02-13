using System.Collections.Generic;

using ClassLibrary;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebApplicationUI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressController : ControllerBase
	{
		private readonly PersonModel _person;
		private AddressModel _address;

		public AddressController(PersonModel person, AddressModel address)
		{
			_person = person;
			_address = address;
		}

		// GET: api/Address
		[HttpGet]
		public IEnumerable<AddressModel> Get()
		{
			return _person.Addresses;
		}

		// GET api/Address/5
		[HttpGet("{id}")]
		public AddressModel Get(int id)
		{
			_address = _person.Addresses[id];
			return _address;
		}

		// POST api/Address
		[HttpPost]
		public void Post([FromBody] AddressModel value)
		{
			_address = value;
			_person.Addresses.Add(_address);
		}

		// PUT api/Address/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] AddressModel value)
		{
			_address = value;
			_person.Addresses[id].StreetAddress = _address.StreetAddress;
			_person.Addresses[id].City = _address.City;
			_person.Addresses[id].State = _address.State;
			_person.Addresses[id].ZipCode = _address.ZipCode;
		}

		// DELETE api/Address/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_person.Addresses.RemoveAt(id);
			_address.StreetAddress = "";
			_address.City = "";
			_address.State = "";
			_address.ZipCode = "";
		}
	}
}
